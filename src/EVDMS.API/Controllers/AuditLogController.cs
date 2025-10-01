using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/audit-logs")]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            this.auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await auditLogService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<AuditLogDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var auditLog = await auditLogService.GetByIdAsync(id);
            if (auditLog == null)
                return NotFound(new ApiResponse<string>("AuditLog not found"));
            return Ok(new ApiResponse<AuditLogDto>(auditLog));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuditLogDto dto)
        {
            var created = await auditLogService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<AuditLogDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuditLogDto dto)
        {
            var success = await auditLogService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("AuditLog not found"));
            return Ok(new ApiResponse<string>(null, "AuditLog updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchAuditLogDto dto)
        {
            var success = await auditLogService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("AuditLog not found"));
            return Ok(new ApiResponse<string>(null, "AuditLog patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await auditLogService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("AuditLog not found"));
            return Ok(new ApiResponse<string>(null, "AuditLog deleted successfully"));
        }
    }
}
