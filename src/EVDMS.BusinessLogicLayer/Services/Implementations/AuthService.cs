using System.Security.Cryptography;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Dtos.Auth;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthService(
            IUserRepository userRepository,
            IUserTokenRepository userTokenRepository,
            IRoleRepository roleRepository,
            IDealerRepository dealerRepository,
            IMapper mapper,
            IJwtService jwtService,
            IEmailService emailService
        )
        {
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _roleRepository = roleRepository;
            _dealerRepository = dealerRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            if (await _userRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception("Email already registered");

            // Find role by name
            var role = (
                await _roleRepository.FindAsync(r => r.RoleName == dto.RoleName)
            ).FirstOrDefault();
            if (role == null)
                throw new Exception($"Role '{dto.RoleName}' does not exist");

            Guid? dealerId = null;
            if (!string.IsNullOrWhiteSpace(dto.DealerName))
            {
                var dealer = (
                    await _dealerRepository.FindAsync(d => d.DealerName == dto.DealerName)
                ).FirstOrDefault();
                if (dealer == null)
                    throw new Exception($"Dealer '{dto.DealerName}' does not exist");
                dealerId = dealer.Id;
            }

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = PasswordHasher.HashPassword(dto.Password);
            user.IsEmailVerified = false;
            user.EmailVerifiedAt = null;
            user.RoleId = role.Id;
            user.DealerId = dealerId;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            // Generate verification token
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));
            var userToken = new UserToken
            {
                UserId = user.Id,
                TokenHash = token,
                Purpose = UserTokenPurpose.EmailVerification,
                ExpiresAt = DateTime.UtcNow.AddHours(24),
                IsUsed = false,
            };
            await _userTokenRepository.AddAsync(userToken);
            await _userTokenRepository.SaveChangesAsync();

            // Send verification email
            var verificationUrl = $"https://your-frontend-url/verify-email?token={token}";
            var emailBody =
                $"<p>Welcome to EVDMS!</p><p>Please <a href='{verificationUrl}'>click here to verify your email</a>.</p>";
            await _emailService.SendEmailAsync(user.Email, "Verify your email", emailBody);

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                FullName = user.FullName,
                Email = user.Email,
                IsEmailVerified = user.IsEmailVerified,
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("Invalid credentials");

            if (!PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                FullName = user.FullName,
                Email = user.Email,
                IsEmailVerified = user.IsEmailVerified,
            };
        }

        public async Task<(bool Success, string Message)> VerifyEmailAsync(string token)
        {
            var userToken = await _userTokenRepository.GetByTokenHashAsync(token);
            if (
                userToken == null
                || userToken.Purpose != UserTokenPurpose.EmailVerification
                || userToken.IsUsed
                || userToken.ExpiresAt < DateTime.UtcNow
            )
            {
                return (false, "Invalid or expired token.");
            }

            var user = await _userRepository.GetByIdAsync(userToken.UserId);
            if (user == null)
            {
                return (false, "User not found.");
            }

            user.IsEmailVerified = true;
            user.EmailVerifiedAt = DateTime.UtcNow;
            userToken.IsUsed = true;
            _userRepository.Update(user);
            _userTokenRepository.Update(userToken);
            await _userRepository.SaveChangesAsync();
            await _userTokenRepository.SaveChangesAsync();

            return (true, "Email verified successfully.");
        }
    }
}
