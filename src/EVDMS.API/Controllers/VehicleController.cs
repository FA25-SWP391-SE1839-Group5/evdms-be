using System.Text.Json;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
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
            var result = await _vehicleService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.Vehicle.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<VehicleDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null)
                return NotFound(new ApiResponse<string>("Vehicle not found"));
            return Ok(new ApiResponse<VehicleDto>(vehicle));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDto dto)
        {
            var created = await _vehicleService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<VehicleDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleDto dto)
        {
            var success = await _vehicleService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Vehicle not found"));
            return Ok(new ApiResponse<string>(null, "Vehicle updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchVehicleDto dto)
        {
            var success = await _vehicleService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Vehicle not found"));
            return Ok(new ApiResponse<string>(null, "Vehicle patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _vehicleService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Vehicle not found"));
            return Ok(new ApiResponse<string>(null, "Vehicle deleted successfully"));
        }
    }
}
