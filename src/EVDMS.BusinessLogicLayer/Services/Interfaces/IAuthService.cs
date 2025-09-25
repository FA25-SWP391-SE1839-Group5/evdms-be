using EVDMS.BusinessLogicLayer.Dtos.Auth;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
        Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<(bool Success, string Message)> VerifyEmailAsync(string token);
        Task LogoutAsync(RefreshTokenRequestDto dto);
    }
}
