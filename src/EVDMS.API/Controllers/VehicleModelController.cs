using System.Text.Json;
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
        private readonly IVehicleModelService _vehicleModelService;
        private readonly ICloudinaryService _cloudinaryService;

        public VehicleModelController(
            IVehicleModelService vehicleModelService,
            ICloudinaryService cloudinaryService
        )
        {
            _vehicleModelService = vehicleModelService;
            _cloudinaryService = cloudinaryService;
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
            var result = await _vehicleModelService.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filterDict,
                DataAccessLayer.Entities.VehicleModel.SearchableColumns
            );
            return Ok(new ApiResponse<PaginatedResult<VehicleModelDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleModel = await _vehicleModelService.GetByIdAsync(id);
            if (vehicleModel == null)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<VehicleModelDto>(vehicleModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleModelDto dto)
        {
            var created = await _vehicleModelService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<VehicleModelDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleModelDto dto)
        {
            var success = await _vehicleModelService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            var updated = await _vehicleModelService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<VehicleModelDto>(updated!, "VehicleModel updated successfully")
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchVehicleModelDto dto)
        {
            var success = await _vehicleModelService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            var updated = await _vehicleModelService.GetByIdAsync(id);
            return Ok(
                new ApiResponse<VehicleModelDto>(updated!, "VehicleModel patched successfully")
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _vehicleModelService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("VehicleModel not found"));
            return Ok(new ApiResponse<string>(null, "VehicleModel deleted successfully"));
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] UploadVehicleModelImageDto dto)
        {
            var image = dto.Image;
            if (image == null || image.Length == 0)
                return BadRequest(new ApiResponse<string>("No image file provided."));

            var allowedTypes = new[]
            {
                "image/jpeg",
                "image/png",
                "image/gif",
                "image/webp",
                "image/bmp",
            };
            if (!allowedTypes.Contains(image.ContentType.ToLower()))
                return BadRequest(
                    new ApiResponse<string>(
                        "Only image files (jpg, png, gif, webp, bmp) are allowed."
                    )
                );

            var imageUrl = await _cloudinaryService.UploadVehicleModelImageAsync(image);
            if (string.IsNullOrEmpty(imageUrl))
                return StatusCode(500, new ApiResponse<string>("Image upload failed."));
            var responseDto = new UploadVehicleModelImageResponseDto { ImageUrl = imageUrl };
            return Ok(
                new ApiResponse<UploadVehicleModelImageResponseDto>(
                    responseDto,
                    "Image uploaded successfully"
                )
            );
        }
    }
}
