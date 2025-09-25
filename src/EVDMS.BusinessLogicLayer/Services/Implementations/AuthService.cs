using System.Security.Cryptography;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Dtos.Auth;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IUserTokenRepository userTokenRepository,
            IRoleRepository roleRepository,
            IDealerRepository dealerRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IMapper mapper,
            IJwtService jwtService,
            IEmailService emailService,
            IConfiguration configuration
        )
        {
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _roleRepository = roleRepository;
            _dealerRepository = dealerRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            if (await _userRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception("Email already registered");

            // Find role by name
            var role = (
                await _roleRepository.FindAsync(r => r.RoleName == dto.Role)
            ).FirstOrDefault();
            if (role == null)
                throw new Exception($"Role '{dto.Role}' does not exist");

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

            // Send verification email using EmailService helper
            var emailSubject = "Verify your email";
            var emailTemplate =
                "<p>Welcome to EVDMS!</p><p>Please <a href='{0}'>click here to verify your email</a>.</p>";
            await _emailService.SendActionEmailAsync(
                user.Email,
                emailSubject,
                "verify-email",
                token,
                emailTemplate
            );

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Store refresh token
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
            };
            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

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

            if (!user.IsEmailVerified)
                throw new Exception(
                    "Email is not verified. Please verify your email before logging in."
                );

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Store refresh token
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7), // Example: 7 days
                IsRevoked = false,
            };
            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                FullName = user.FullName,
                Email = user.Email,
                IsEmailVerified = user.IsEmailVerified,
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var existingToken = await _refreshTokenRepository.GetByTokenHashAsync(dto.RefreshToken);
            if (
                existingToken == null
                || existingToken.IsRevoked
                || existingToken.ExpiresAt < DateTime.UtcNow
            )
                throw new Exception("Invalid or expired refresh token");

            var user = await _userRepository.GetByIdAsync(existingToken.UserId);
            if (user == null)
                throw new Exception("User not found");

            // Revoke old token
            existingToken.IsRevoked = true;
            _refreshTokenRepository.Update(existingToken);

            // Issue new tokens
            var newAccessToken = _jwtService.GenerateAccessToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();
            var newRefreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = newRefreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
            };
            await _refreshTokenRepository.AddAsync(newRefreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
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
