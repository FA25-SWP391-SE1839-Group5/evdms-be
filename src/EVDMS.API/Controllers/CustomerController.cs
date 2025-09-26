using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var result = await _customerService.GetAllAsync(page, pageSize);
            return Ok(new ApiResponse<PaginatedResult<CustomerDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound(new ApiResponse<string>("Customer not found"));
            return Ok(new ApiResponse<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var created = await _customerService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<CustomerDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
        {
            var success = await _customerService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Customer not found"));
            return Ok(new ApiResponse<string>(null, "Customer updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchCustomerDto dto)
        {
            var success = await _customerService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Customer not found"));
            return Ok(new ApiResponse<string>(null, "Customer patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _customerService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Customer not found"));
            return Ok(new ApiResponse<string>(null, "Customer deleted successfully"));
        }
    }
}
