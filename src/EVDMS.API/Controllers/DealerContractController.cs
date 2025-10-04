using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/dealer-contracts")]
    public class DealerContractController : ControllerBase
    {
        private readonly IDealerContractService _dealerContractService;

        public DealerContractController(IDealerContractService dealerContractService)
        {
            _dealerContractService = dealerContractService;
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
            var result = await _dealerContractService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.DealerContract.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<DealerContractDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contract = await _dealerContractService.GetByIdAsync(id);
            if (contract == null)
                return NotFound(new ApiResponse<string>("DealerContract not found"));
            return Ok(new ApiResponse<DealerContractDto>(contract));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDealerContractDto dto)
        {
            var created = await _dealerContractService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<DealerContractDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDealerContractDto dto)
        {
            var success = await _dealerContractService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerContract not found"));
            var updated = await _dealerContractService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerContractDto>(updated!, "DealerContract updated successfully")
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchDealerContractDto dto)
        {
            var success = await _dealerContractService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerContract not found"));
            var updated = await _dealerContractService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerContractDto>(updated!, "DealerContract patched successfully")
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _dealerContractService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerContract not found"));
            return Ok(new ApiResponse<string>(null, "DealerContract deleted successfully"));
        }
    }
}
