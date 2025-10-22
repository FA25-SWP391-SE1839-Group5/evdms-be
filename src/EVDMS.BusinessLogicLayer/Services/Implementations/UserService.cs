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
                _ =
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

            // Basic syntax check and MX/A record verification to reduce fake emails
            if (!EmailVerifier.IsValidFormat(dto.Email))
                throw new Exception("The provided email address has an invalid format.");

            var domainIsValid = await EmailVerifier.DomainHasMailServerAsync(dto.Email);
            if (!domainIsValid)
                throw new Exception(
                    "The email domain does not appear to accept mail (no MX/A records)."
                );

            if (EmailVerifier.IsDisposableDomain(dto.Email))
                throw new Exception("Disposable or temporary email addresses are not allowed.");

            if (await _userRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception($"A user with email '{dto.Email}' already exists.");

            var tempPassword = GenerateTemporaryPassword();
            var passwordHash = PasswordHasher.HashPassword(tempPassword);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var subject = "Your Account Has Been Created";
            var templatePath = Path.Combine(
                AppContext.BaseDirectory,
                "EmailTemplates",
                "AccountCreated.html"
            );

            string body;
            if (File.Exists(templatePath))
            {
                body = await File.ReadAllTextAsync(templatePath);
                body = body.Replace("{FullName}", user.FullName)
                    .Replace("{TempPassword}", tempPassword)
                    .Replace("{Year}", DateTime.UtcNow.Year.ToString());
            }
            else
            {
                body =
                    $"Hello {user.FullName}, your account has been created. Your temporary password is: {tempPassword}";
            }

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
