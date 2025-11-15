using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/dealers")]
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
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
            var result = await _dealerService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.Dealer.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<DealerDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dealer = await _dealerService.GetByIdAsync(id);
            if (dealer == null)
                return NotFound(new ApiResponse<string>("Dealer not found"));
            return Ok(new ApiResponse<DealerDto>(dealer));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDealerDto dto)
        {
            var created = await _dealerService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<DealerDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDealerDto dto)
        {
            var success = await _dealerService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Dealer not found"));
            var updated = await _dealerService.GetByIdAsync(id);
            return Ok(new ApiResponse<DealerDto>(updated!, "Dealer updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchDealerDto dto)
        {
            var success = await _dealerService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Dealer not found"));
            var updated = await _dealerService.GetByIdAsync(id);
            return Ok(new ApiResponse<DealerDto>(updated!, "Dealer patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _dealerService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Dealer not found"));
            return Ok(new ApiResponse<string>(null, "Dealer deleted successfully"));
        }
    }
}
