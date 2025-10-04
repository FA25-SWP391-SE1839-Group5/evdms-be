using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/sales-orders")]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _salesOrderService;

        public SalesOrderController(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
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
            var result = await _salesOrderService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.SalesOrder.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<SalesOrderDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var salesOrder = await _salesOrderService.GetByIdAsync(id);
            if (salesOrder == null)
                return NotFound(new ApiResponse<string>("SalesOrder not found"));
            return Ok(new ApiResponse<SalesOrderDto>(salesOrder));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderDto dto)
        {
            var created = await _salesOrderService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<SalesOrderDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSalesOrderDto dto)
        {
            var success = await _salesOrderService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("SalesOrder not found"));
            var updated = await _salesOrderService.GetByIdAsync(id);
            return Ok(new ApiResponse<SalesOrderDto>(updated!, "SalesOrder updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchSalesOrderDto dto)
        {
            var success = await _salesOrderService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("SalesOrder not found"));
            var updated = await _salesOrderService.GetByIdAsync(id);
            return Ok(new ApiResponse<SalesOrderDto>(updated!, "SalesOrder patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _salesOrderService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("SalesOrder not found"));
            return Ok(new ApiResponse<string>(null, "SalesOrder deleted successfully"));
        }
    }
}
