using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null,
            [FromQuery] string? search = null,
            [FromQuery] string? filters = null
        )
        {
            Dictionary<string, string>? filterDict = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterDict = JsonSerializer.Deserialize<Dictionary<string, string>>(filters);
            }
            var result = await _userService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.User.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<UserDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new ApiResponse<string>("User not found"));
            return Ok(new ApiResponse<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            try
            {
                var currentUserRole = JwtUtils.GetUserRoleFromClaims(User);
                if (currentUserRole == null)
                    return StatusCode(
                        403,
                        new ApiResponse<string>("You are not allowed to create users.")
                    );

                var created = await _userService.CreateAsync(dto, currentUserRole.Value);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = created.Id },
                    new ApiResponse<UserDto>(created)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var success = await _userService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("User not found"));
            var updated = await _userService.GetByIdAsync(id);
            return Ok(new ApiResponse<UserDto>(updated!, "User updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchUserDto dto)
        {
            var success = await _userService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("User not found"));
            var updated = await _userService.GetByIdAsync(id);
            return Ok(new ApiResponse<UserDto>(updated!, "User patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("User not found"));
            return Ok(new ApiResponse<string>(null, "User deleted successfully"));
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = JwtUtils.GetUserIdFromClaims(User);
            if (userId == null)
                return Unauthorized(
                    new ApiResponse<string>("Invalid or missing user ID in token.")
                );

            var user = await _userService.GetCurrentUserAsync(userId.Value);
            if (user == null)
                return NotFound(new ApiResponse<string>("User not found"));
            return Ok(new ApiResponse<UserDto>(user));
        }
    }
}
