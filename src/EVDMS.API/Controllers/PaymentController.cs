using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await paymentService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<PaymentDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var payment = await paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound(new ApiResponse<string>("Payment not found"));
            return Ok(new ApiResponse<PaymentDto>(payment));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDto dto)
        {
            var created = await paymentService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<PaymentDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaymentDto dto)
        {
            var success = await paymentService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Payment not found"));
            return Ok(new ApiResponse<string>(null, "Payment updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchPaymentDto dto)
        {
            var success = await paymentService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Payment not found"));
            return Ok(new ApiResponse<string>(null, "Payment patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await paymentService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Payment not found"));
            return Ok(new ApiResponse<string>(null, "Payment deleted successfully"));
        }
    }
}
