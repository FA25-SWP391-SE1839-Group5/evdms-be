using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/vehicle-variants")]
    public class VehicleVariantController : ControllerBase
    {
        private readonly IVehicleVariantService vehicleVariantService;

        public VehicleVariantController(IVehicleVariantService vehicleVariantService)
        {
            this.vehicleVariantService = vehicleVariantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await vehicleVariantService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<VehicleVariantDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleVariant = await vehicleVariantService.GetByIdAsync(id);
            if (vehicleVariant == null)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<VehicleVariantDto>(vehicleVariant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleVariantDto dto)
        {
            var created = await vehicleVariantService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<VehicleVariantDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleVariantDto dto)
        {
            var success = await vehicleVariantService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<string>(null, "VehicleVariant updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchVehicleVariantDto dto)
        {
            var success = await vehicleVariantService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<string>(null, "VehicleVariant patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await vehicleVariantService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<string>(null, "VehicleVariant deleted successfully"));
        }
    }
}
