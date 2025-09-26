using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Dtos.Auth;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var result = await _authService.RegisterAsync(dto);
                return Ok(new ApiResponse<AuthResponseDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(new ApiResponse<AuthResponseDto>(result));
            }
            catch (Exception ex)
            {
                return Unauthorized(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto dto)
        {
            try
            {
                var result = await _authService.RefreshTokenAsync(dto);
                return Ok(new ApiResponse<AuthResponseDto>(result));
            }
            catch (Exception ex)
            {
                return Unauthorized(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string token)
        {
            var success = await _authService.VerifyEmailAsync(token);
            if (!success)
            {
                return BadRequest(new ApiResponse<string>("Invalid or expired token."));
            }
            return Ok(new ApiResponse<string>(null, "Email verified successfully."));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequestDto dto)
        {
            var success = await _authService.LogoutAsync(dto);
            if (!success)
            {
                return BadRequest(
                    new ApiResponse<string>(
                        "Logout failed. Token may be invalid or already revoked."
                    )
                );
            }
            return Ok(new ApiResponse<string>(null, "Logged out successfully."));
        }
    }
}
