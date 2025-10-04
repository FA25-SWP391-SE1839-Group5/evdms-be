using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/quotations")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
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
            var result = await _quotationService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.Quotation.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<QuotationDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var quotation = await _quotationService.GetByIdAsync(id);
            if (quotation == null)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<QuotationDto>(quotation));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuotationDto dto)
        {
            var created = await _quotationService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<QuotationDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQuotationDto dto)
        {
            var success = await _quotationService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            var updated = await _quotationService.GetByIdAsync(id);
            return Ok(new ApiResponse<QuotationDto>(updated!, "Quotation updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchQuotationDto dto)
        {
            var success = await _quotationService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            var updated = await _quotationService.GetByIdAsync(id);
            return Ok(new ApiResponse<QuotationDto>(updated!, "Quotation patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _quotationService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<string>(null, "Quotation deleted successfully"));
        }
    }
}
