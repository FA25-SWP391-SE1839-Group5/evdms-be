using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class UserService
        : BaseService<User, UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>,
            IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IEmailService _emailService;

        public UserService(
            IUserRepository userRepository,
            IDealerRepository dealerRepository,
            IMapper mapper,
            IEmailService emailService
        )
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _dealerRepository = dealerRepository;
            _emailService = emailService;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto, UserRole currentUserRole)
        {
            if (currentUserRole == UserRole.Admin) { }
            else if (currentUserRole == UserRole.DealerManager)
            {
                if (dto.Role != UserRole.DealerStaff)
                    throw new Exception("Dealer managers can only create Dealer Staff users.");
            }
            else
            {
                throw new Exception("You are not allowed to create users.");
            }

            if (dto.DealerId != null)
            {
                var dealer =
                    await _dealerRepository.GetByIdAsync(dto.DealerId.Value)
                    ?? throw new Exception("Dealer not found.");
                if (dto.Role != UserRole.DealerStaff && dto.Role != UserRole.DealerManager)
                    throw new Exception(
                        "If DealerId is provided, role must be DealerStaff or DealerManager."
                    );
            }
            else
            {
                if (dto.Role != UserRole.EvmStaff && dto.Role != UserRole.Admin)
                    throw new Exception("If DealerId is null, role must be EvmStaff or Admin.");
            }

            if (await _userRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception($"A user with email '{dto.Email}' already exists.");

            var tempPassword = GenerateTemporaryPassword();
            var passwordHash = PasswordHasher.HashPassword(tempPassword);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var subject = "Your Account Has Been Created";
            var body =
                $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Account Created</title>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #f4f6fb; margin: 0; padding: 0; }}
        .container {{ max-width: 480px; margin: 40px auto; background: #fff; border-radius: 12px; box-shadow: 0 2px 8px rgba(0,0,0,0.07); padding: 32px 24px; }}
        .logo {{ text-align: center; margin-bottom: 24px; }}
        .logo img {{ width: 64px; height: 64px; }}
        h2 {{ color: #2d3a4b; margin-bottom: 8px; }}
        p {{ color: #4a5568; line-height: 1.6; }}
        .password {{ background: #f4f6fb; padding: 12px; border-radius: 8px; font-size: 1.1em; text-align: center; margin: 16px 0; font-weight: bold; letter-spacing: 1px; }}
        .footer {{ text-align: center; color: #a0aec0; font-size: 0.95em; margin-top: 24px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='logo'>
            <img src='https://cdn-icons-png.flaticon.com/512/561/561127.png' alt='Logo'>
        </div>
        <h2>Welcome to EVDMS!</h2>
        <p>Hello {user.FullName},</p>
        <p>Your account has been created. Your temporary password is:</p>
        <div class='password'>{tempPassword}</div>
        <p>Please change your password after logging in.</p>
        <div class='footer'>
            &copy; {DateTime.UtcNow.Year} EVDMS. All rights reserved.
        </div>
    </div>
</body>
</html>
";
            await _emailService.SendEmailAsync(user.Email, subject, body);

            return _mapper.Map<UserDto>(user);
        }

        private static string GenerateTemporaryPassword(int length = 12)
        {
            const string valid =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            var res = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                var uintBuffer = new byte[sizeof(uint)];
                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    var num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }

        public async Task<UserDto?> GetCurrentUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;
            return _mapper.Map<UserDto>(user);
        }
    }
}
