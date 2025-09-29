using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/promotions")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            this.promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await promotionService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<PromotionDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var promotion = await promotionService.GetByIdAsync(id);
            if (promotion == null)
                return NotFound(new ApiResponse<string>("Promotion not found"));
            return Ok(new ApiResponse<PromotionDto>(promotion));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePromotionDto dto)
        {
            var created = await promotionService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<PromotionDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePromotionDto dto)
        {
            var success = await promotionService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Promotion not found"));
            return Ok(new ApiResponse<string>(null, "Promotion updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchPromotionDto dto)
        {
            var success = await promotionService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Promotion not found"));
            return Ok(new ApiResponse<string>(null, "Promotion patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await promotionService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Promotion not found"));
            return Ok(new ApiResponse<string>(null, "Promotion deleted successfully"));
        }
    }
}
