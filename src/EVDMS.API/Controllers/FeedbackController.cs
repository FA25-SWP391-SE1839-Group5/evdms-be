using System.Text.Json;
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
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
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
            var result = await _feedbackService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.Feedback.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<FeedbackDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var feedback = await _feedbackService.GetByIdAsync(id);
            if (feedback == null)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<FeedbackDto>(feedback));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFeedbackDto dto)
        {
            var created = await _feedbackService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<FeedbackDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFeedbackDto dto)
        {
            var success = await _feedbackService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchFeedbackDto dto)
        {
            var success = await _feedbackService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _feedbackService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Feedback not found"));
            return Ok(new ApiResponse<string>(null, "Feedback deleted successfully"));
        }
    }
}
