using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/oem-inventories")]
    public class OemInventoryController : ControllerBase
    {
        private readonly IOemInventoryService _oemInventoryService;

        public OemInventoryController(IOemInventoryService oemInventoryService)
        {
            _oemInventoryService = oemInventoryService;
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
            var result = await _oemInventoryService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.OemInventory.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<OemInventoryDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var oemInventory = await _oemInventoryService.GetByIdAsync(id);
            if (oemInventory == null)
                return NotFound(new ApiResponse<string>("OemInventory not found"));
            return Ok(new ApiResponse<OemInventoryDto>(oemInventory));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOemInventoryDto dto)
        {
            var created = await _oemInventoryService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<OemInventoryDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOemInventoryDto dto)
        {
            var success = await _oemInventoryService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("OemInventory not found"));
            return Ok(new ApiResponse<string>(null, "OemInventory updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchOemInventoryDto dto)
        {
            var success = await _oemInventoryService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("OemInventory not found"));
            return Ok(new ApiResponse<string>(null, "OemInventory patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _oemInventoryService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("OemInventory not found"));
            return Ok(new ApiResponse<string>(null, "OemInventory deleted successfully"));
        }
    }
}
