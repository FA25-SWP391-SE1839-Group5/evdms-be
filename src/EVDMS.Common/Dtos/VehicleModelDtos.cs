using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EVDMS.Common.Dtos
{
    public class VehicleModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVehicleModelDto
    {
        [Required]
        [MinLength(1)]
        public required string Name { get; set; }

        [Required]
        [MinLength(1)]
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class UploadVehicleModelImageDto
    {
        [Required]
        public IFormFile Image { get; set; } = default!;
    }

    public class UpdateVehicleModelDto
    {
        [Required]
        [MinLength(1)]
        public required string Name { get; set; }

        [Required]
        [MinLength(1)]
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class PatchVehicleModelDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
