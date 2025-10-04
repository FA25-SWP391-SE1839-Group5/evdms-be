using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/dealer-orders")]
    public class DealerOrderController : ControllerBase
    {
        private readonly IDealerOrderService _dealerOrderService;

        public DealerOrderController(IDealerOrderService dealerOrderService)
        {
            _dealerOrderService = dealerOrderService;
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
            var result = await _dealerOrderService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.DealerOrder.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<DealerOrderDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dealerOrder = await _dealerOrderService.GetByIdAsync(id);
            if (dealerOrder == null)
                return NotFound(new ApiResponse<string>("DealerOrder not found"));
            return Ok(new ApiResponse<DealerOrderDto>(dealerOrder));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDealerOrderDto dto)
        {
            var created = await _dealerOrderService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<DealerOrderDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDealerOrderDto dto)
        {
            var success = await _dealerOrderService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerOrder not found"));
            var updated = await _dealerOrderService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerOrderDto>(updated!, "DealerOrder updated successfully")
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchDealerOrderDto dto)
        {
            var success = await _dealerOrderService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerOrder not found"));
            var updated = await _dealerOrderService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerOrderDto>(updated!, "DealerOrder patched successfully")
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _dealerOrderService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerOrder not found"));
            return Ok(new ApiResponse<string>(null, "DealerOrder deleted successfully"));
        }
    }
}
