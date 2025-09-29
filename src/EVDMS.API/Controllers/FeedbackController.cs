using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/feedbacks")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await feedbackService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<FeedbackDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var feedback = await feedbackService.GetByIdAsync(id);
            if (feedback == null)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<FeedbackDto>(feedback));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFeedbackDto dto)
        {
            var created = await feedbackService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<FeedbackDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFeedbackDto dto)
        {
            var success = await feedbackService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchFeedbackDto dto)
        {
            var success = await feedbackService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await feedbackService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback deleted successfully"));
        }
    }
}
