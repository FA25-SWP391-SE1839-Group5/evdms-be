using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/dealer-payments")]
    public class DealerPaymentController : ControllerBase
    {
        private readonly IDealerPaymentService _dealerPaymentService;

        public DealerPaymentController(IDealerPaymentService dealerPaymentService)
        {
            _dealerPaymentService = dealerPaymentService;
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
            var result = await _dealerPaymentService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DealerPayment.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<DealerPaymentDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dealerPayment = await _dealerPaymentService.GetByIdAsync(id);
            if (dealerPayment == null)
                return NotFound(new ApiResponse<string>("DealerPayment not found"));
            return Ok(new ApiResponse<DealerPaymentDto>(dealerPayment));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDealerPaymentDto dto)
        {
            try
            {
                var created = await _dealerPaymentService.CreateAsync(dto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = created.Id },
                    new ApiResponse<DealerPaymentDto>(created)
                );
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDealerPaymentDto dto)
        {
            var success = await _dealerPaymentService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerPayment not found"));
            var updated = await _dealerPaymentService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerPaymentDto>(updated!, "DealerPayment updated successfully")
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchDealerPaymentDto dto)
        {
            var success = await _dealerPaymentService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerPayment not found"));
            var updated = await _dealerPaymentService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<DealerPaymentDto>(updated!, "DealerPayment patched successfully")
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _dealerPaymentService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("DealerPayment not found"));
            return Ok(new ApiResponse<string>(null, "DealerPayment deleted successfully"));
        }

        [HttpPost("{id}/mark-paid")]
        public async Task<IActionResult> MarkPaid(Guid id)
        {
            try
            {
                await _dealerPaymentService.MarkPaymentPaidAsync(id);
                return Ok(
                    new ApiResponse<string>(null, "Payment marked as Paid and dealer debt reduced.")
                );
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPost("{id}/mark-failed")]
        public async Task<IActionResult> MarkFailed(Guid id)
        {
            try
            {
                await _dealerPaymentService.MarkPaymentFailedAsync(id);
                return Ok(
                    new ApiResponse<string>(
                        null,
                        "Payment marked as Failed, order canceled, inventory restored, and dealer debt reduced."
                    )
                );
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ApiResponse<string>(ex.Message));
            }
        }
    }
}
