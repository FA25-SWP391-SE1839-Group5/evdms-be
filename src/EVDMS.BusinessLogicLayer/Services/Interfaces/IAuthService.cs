using EVDMS.Common.Dtos;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);
        Task<RefreshTokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<bool> LogoutAsync(RefreshTokenRequestDto dto);
        Task<bool> RequestPasswordResetAsync(PasswordResetRequestDto dto);
        Task<bool> ResetPasswordAsync(string token, PasswordResetDto dto);
    }
}
