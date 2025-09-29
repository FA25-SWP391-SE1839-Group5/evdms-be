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
        private readonly IQuotationService quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            this.quotationService = quotationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await quotationService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<QuotationDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var quotation = await quotationService.GetByIdAsync(id);
            if (quotation == null)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<QuotationDto>(quotation));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuotationDto dto)
        {
            var created = await quotationService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<QuotationDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQuotationDto dto)
        {
            var success = await quotationService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<string>(null, "Quotation updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchQuotationDto dto)
        {
            var success = await quotationService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<string>(null, "Quotation patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await quotationService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Quotation not found"));
            return Ok(new ApiResponse<string>(null, "Quotation deleted successfully"));
        }
    }
}
