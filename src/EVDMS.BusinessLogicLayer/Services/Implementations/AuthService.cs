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

            var emailSubject = "Verify your email";
            var emailTemplate =
                @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Verify Your Email</title>
    <style>
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            background: #f4f6fb;
            margin: 0;
            padding: 0;
        }}
        .container {{
            max-width: 480px;
            margin: 40px auto;
            background: #fff;
            border-radius: 12px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.07);
            padding: 32px 24px;
        }}
        .logo {{
            text-align: center;
            margin-bottom: 24px;
        }}
        .logo img {{
            width: 64px;
            height: 64px;
        }}
        h2 {{
            color: #2d3a4b;
            margin-bottom: 8px;
        }}
        p {{
            color: #4a5568;
            line-height: 1.6;
        }}
        .verify-btn {{
            display: inline-block;
            background: #2563eb;
            color: #fff !important;
            padding: 12px 32px;
            border-radius: 6px;
            text-decoration: none;
            font-weight: 600;
            margin: 20px 0;
        }}
        .footer {{
            text-align: center;
            color: #a0aec0;
            font-size: 0.95em;
            margin-top: 24px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='logo'>
            <img src='https://cdn-icons-png.flaticon.com/512/561/561127.png' alt='Logo'>
        </div>
        <h2>Welcome to EVDMS!</h2>
        <p>Thank you for registering. To complete your registration, please verify your email address by clicking the button below:</p>
        <p style='text-align:center;'>
            <a href='{0}' class='verify-btn'>Verify Email</a>
        </p>
        <p>If the button doesn't work, copy and paste this link into your browser:</p>
        <p style='word-break:break-all;'>{0}</p>
        <p>If you did not create an account, you can safely ignore this email.</p>
        <div class='footer'>
            &copy; {1} EVDMS. All rights reserved.
        </div>
    </div>
</body>
</html>
";
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

            user.LastLoginAt = DateTime.UtcNow;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

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

        public async Task<bool> VerifyEmailAsync(string token)
        {
            var userToken = await _userTokenRepository.GetByTokenHashAsync(token);
            if (
                userToken == null
                || userToken.Purpose != UserTokenPurpose.EmailVerification
                || userToken.IsUsed
                || userToken.ExpiresAt < DateTime.UtcNow
            )
            {
                return false;
            }

            var user = await _userRepository.GetByIdAsync(userToken.UserId);
            if (user == null)
            {
                return false;
            }

            user.IsEmailVerified = true;
            user.EmailVerifiedAt = DateTime.UtcNow;
            userToken.IsUsed = true;
            _userRepository.Update(user);
            _userTokenRepository.Update(userToken);
            await _userRepository.SaveChangesAsync();
            await _userTokenRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LogoutAsync(RefreshTokenRequestDto dto)
        {
            var token = await _refreshTokenRepository.GetByTokenHashAsync(dto.RefreshToken);
            if (token != null && !token.IsRevoked)
            {
                token.IsRevoked = true;
                _refreshTokenRepository.Update(token);
                await _refreshTokenRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
