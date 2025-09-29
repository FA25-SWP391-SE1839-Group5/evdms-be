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

            // Generate token
            var token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiresAt = DateTime.UtcNow.AddHours(1);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            // Build reset link using configuration
            var baseUrl = _configuration["App:BaseUrl"] ?? "http://localhost:3000";
            var resetLink = $"{baseUrl}/reset-password?token={token}";
            var subject = "Password Reset Request";
            var body =
                $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Password Reset</title>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #f4f6fb; margin: 0; padding: 0; }}
        .container {{ max-width: 480px; margin: 40px auto; background: #fff; border-radius: 12px; box-shadow: 0 2px 8px rgba(0,0,0,0.07); padding: 32px 24px; }}
        .logo {{ text-align: center; margin-bottom: 24px; }}
        .logo img {{ width: 64px; height: 64px; }}
        h2 {{ color: #2d3a4b; margin-bottom: 8px; }}
        p {{ color: #4a5568; line-height: 1.6; }}
        .button {{ display: block; width: 100%; text-align: center; margin: 24px 0; }}
        a.reset-btn {{ background: #2d3a4b; color: #fff; text-decoration: none; padding: 12px 24px; border-radius: 8px; font-size: 1.1em; font-weight: bold; display: inline-block; }}
        .footer {{ text-align: center; color: #a0aec0; font-size: 0.95em; margin-top: 24px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='logo'>
            <img src='https://cdn-icons-png.flaticon.com/512/561/561127.png' alt='Logo'>
        </div>
        <h2>Password Reset Request</h2>
        <p>Hello {user.FullName},</p>
        <p>We received a request to reset your password. Click the button below to reset your password. This link will expire in 1 hour.</p>
        <div class='button'>
            <a class='reset-btn' href='{resetLink}'>Reset Password</a>
        </div>
        <p>If you did not request a password reset, you can safely ignore this email.</p>
        <div class='footer'>
            &copy; {DateTime.UtcNow.Year} EVDMS. All rights reserved.
        </div>
    </div>
</body>
</html>
";
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
