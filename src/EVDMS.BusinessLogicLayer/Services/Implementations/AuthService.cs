using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Settings;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IJwtService jwtService,
            IOptions<JwtSettings> jwtOptions
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _jwtSettings = jwtOptions.Value;
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
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                TokenHash = PasswordHasher.HashPassword(refreshToken),
                ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays),
                IsRevoked = false,
                User = user,
            };
            user.RefreshTokens.Add(refreshTokenEntity);
            await _userRepository.SaveChangesAsync();

            response.RefreshToken = refreshToken;
            return response;
        }
    }
}
