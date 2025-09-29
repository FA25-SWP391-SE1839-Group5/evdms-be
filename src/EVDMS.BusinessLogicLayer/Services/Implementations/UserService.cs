using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IEmailService emailService
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<PaginatedResult<UserDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var (users, totalCount) = await _userRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder
            );
            return new PaginatedResult<UserDto>
            {
                Items = _mapper.Map<IEnumerable<UserDto>>(users),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var tempPassword = GenerateTemporaryPassword();
            var passwordHash = PasswordHasher.HashPassword(tempPassword);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var subject = "Your Account Has Been Created";
            var body =
                $"Hello {user.FullName},<br/><br/>Your account has been created. Your temporary password is: <b>{tempPassword}</b><br/>Please change your password after logging in.";
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

        public async Task<bool> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _mapper.Map(dto, user);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(Guid id, PatchUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _mapper.Map(dto, user);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
