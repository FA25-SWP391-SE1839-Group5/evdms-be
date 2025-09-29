using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/vehicle-models")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            this.vehicleModelService = vehicleModelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await vehicleModelService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<VehicleModelDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleModel = await vehicleModelService.GetByIdAsync(id);
            if (vehicleModel == null)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<VehicleModelDto>(vehicleModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleModelDto dto)
        {
            var created = await vehicleModelService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<VehicleModelDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleModelDto dto)
        {
            var success = await vehicleModelService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<string>(null, "VehicleModel updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchVehicleModelDto dto)
        {
            var success = await vehicleModelService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<string>(null, "VehicleModel patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await vehicleModelService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<string>(null, "VehicleModel deleted successfully"));
        }
    }
}
