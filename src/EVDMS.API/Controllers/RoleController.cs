using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var result = await _roleService.GetAllAsync(page, pageSize);
            return Ok(new ApiResponse<PaginatedResult<RoleDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
                return NotFound(new ApiResponse<string>("Role not found"));
            return Ok(new ApiResponse<RoleDto>(role));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var created = await _roleService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<RoleDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoleDto dto)
        {
            var success = await _roleService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Role not found"));
            return Ok(new ApiResponse<string>(null, "Role updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchRoleDto dto)
        {
            var success = await _roleService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Role not found"));
            return Ok(new ApiResponse<string>(null, "Role patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _roleService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Role not found"));
            return Ok(new ApiResponse<string>(null, "Role deleted successfully"));
        }
    }
}
