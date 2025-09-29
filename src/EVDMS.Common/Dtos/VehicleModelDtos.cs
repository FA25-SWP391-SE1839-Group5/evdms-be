using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class VehicleModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVehicleModelDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;
    }

    public class UpdateVehicleModelDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;
    }

    public class PatchVehicleModelDto
    {
        public string? Name { get; set; }
    }
}
