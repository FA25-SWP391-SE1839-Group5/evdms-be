using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
                return Unauthorized(
                    new ApiResponse<string>("Invalid credentials or inactive user.")
                );
            return Ok(new ApiResponse<LoginResponseDto>(result));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);
            if (result == null)
                return Unauthorized(new ApiResponse<string>("Invalid or expired refresh token."));
            return Ok(new ApiResponse<RefreshTokenResponseDto>(result));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequestDto dto)
        {
            var success = await _authService.LogoutAsync(dto);
            if (!success)
                return BadRequest(
                    new ApiResponse<string>("Invalid or already revoked refresh token.")
                );
            return Ok(new ApiResponse<string>(null, "Logout successful."));
        }

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset(
            [FromBody] PasswordResetRequestDto dto
        )
        {
            var result = await _authService.RequestPasswordResetAsync(dto);
            if (!result)
                return BadRequest(new ApiResponse<string>("User not found or inactive."));
            return Ok(new ApiResponse<string>(null, "Password reset link sent successfully."));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(
            [FromQuery] string token,
            [FromBody] PasswordResetDto dto
        )
        {
            var result = await _authService.ResetPasswordAsync(token, dto);
            if (!result)
                return BadRequest(new ApiResponse<string>("Password reset failed."));
            return Ok(new ApiResponse<string>(null, "Password has been reset successfully."));
        }
    }
}
