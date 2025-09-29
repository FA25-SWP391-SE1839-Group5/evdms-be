using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Settings;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IJwtService jwtService,
            IOptions<JwtSettings> jwtOptions,
            IRefreshTokenRepository refreshTokenRepository,
            IEmailService emailService,
            IConfiguration configuration
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _jwtSettings = jwtOptions.Value;
            _refreshTokenRepository = refreshTokenRepository;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !user.IsActive)
                return null;
            if (!PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return null;

            user.LastLoginAt = DateTime.UtcNow;

            var response = _mapper.Map<LoginResponseDto>(user);
            response.AccessToken = _jwtService.GenerateAccessToken(user);

            var refreshToken = _jwtService.GenerateRefreshToken();
            var refreshTokenHash = JwtService.HashRefreshToken(refreshToken);
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshTokenHash,
                ExpiresAt = JwtService.GetRefreshTokenExpiryDate(
                    _jwtSettings.RefreshTokenExpirationDays
                ),
                IsRevoked = false,
                User = user,
            };
            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();
            response.RefreshToken = refreshToken;
            return response;
        }

        public async Task<RefreshTokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var refreshTokenHash = JwtService.HashRefreshToken(dto.RefreshToken);
            var storedToken = await _refreshTokenRepository.GetByTokenHashAsync(refreshTokenHash);
            if (
                storedToken == null
                || storedToken.IsRevoked
                || storedToken.ExpiresAt < DateTime.UtcNow
            )
                return null;
            var user = storedToken.User;
            var newAccessToken = _jwtService.GenerateAccessToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();
            var newRefreshTokenHash = JwtService.HashRefreshToken(newRefreshToken);
            storedToken.IsRevoked = true;
            _refreshTokenRepository.Update(storedToken);
            await _refreshTokenRepository.SaveChangesAsync();
            var newRefreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = newRefreshTokenHash,
                ExpiresAt = JwtService.GetRefreshTokenExpiryDate(
                    _jwtSettings.RefreshTokenExpirationDays
                ),
                IsRevoked = false,
                User = user,
            };
            await _refreshTokenRepository.AddAsync(newRefreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();
            return new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }

        public async Task<bool> LogoutAsync(RefreshTokenRequestDto dto)
        {
            var refreshTokenHash = JwtService.HashRefreshToken(dto.RefreshToken);
            var storedToken = await _refreshTokenRepository.GetByTokenHashAsync(refreshTokenHash);
            if (storedToken == null || storedToken.IsRevoked)
                return false;
            await _refreshTokenRepository.RevokeAsync(refreshTokenHash);
            return true;
        }

        public async Task<bool> RequestPasswordResetAsync(PasswordResetRequestDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !user.IsActive)
                return false;

            var token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiresAt = DateTime.UtcNow.AddHours(1);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            var baseUrl = _configuration["App:BaseUrl"] ?? "http://localhost:3000";
            var resetLink = $"{baseUrl}/reset-password?token={token}";
            var subject = "Password Reset Request";
            var body =
                $"<p>Click <a href='{resetLink}'>here</a> to reset your password. This link expires in 1 hour.</p>";
            await _emailService.SendEmailAsync(user.Email, subject, body);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string token, PasswordResetDto dto)
        {
            var user = (
                await _userRepository.FindAsync(u => u.PasswordResetToken == token)
            ).FirstOrDefault();
            if (
                user == null
                || user.PasswordResetTokenExpiresAt == null
                || user.PasswordResetTokenExpiresAt < DateTime.UtcNow
            )
            {
                return false;
            }
            if (!PasswordHasher.VerifyPassword(dto.OldPassword, user.PasswordHash))
            {
                return false;
            }
            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                return false;
            }
            user.PasswordHash = PasswordHasher.HashPassword(dto.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiresAt = null;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
