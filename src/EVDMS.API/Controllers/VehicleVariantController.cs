using System.Text.Json;
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
        private readonly IVehicleVariantService _vehicleVariantService;

        public VehicleVariantController(IVehicleVariantService vehicleVariantService)
        {
            _vehicleVariantService = vehicleVariantService;
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
            var result = await _vehicleVariantService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.VehicleVariant.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<VehicleVariantDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleVariant = await _vehicleVariantService.GetByIdAsync(id);
            if (vehicleVariant == null)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<VehicleVariantDto>(vehicleVariant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleVariantDto dto)
        {
            var created = await _vehicleVariantService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<VehicleVariantDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleVariantDto dto)
        {
            var success = await _vehicleVariantService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            var updated = await _vehicleVariantService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<VehicleVariantDto>(updated!, "VehicleVariant updated successfully")
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchVehicleVariantDto dto)
        {
            var success = await _vehicleVariantService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            var updated = await _vehicleVariantService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<VehicleVariantDto>(updated!, "VehicleVariant patched successfully")
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _vehicleVariantService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleVariant not found"));
            return Ok(new ApiResponse<string>(null, "VehicleVariant deleted successfully"));
        }
    }
}
