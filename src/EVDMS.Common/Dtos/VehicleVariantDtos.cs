using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class VehicleVariantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid VehicleModelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVehicleVariantDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required Guid VehicleModelId { get; set; }
    }

    public class UpdateVehicleVariantDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required Guid VehicleModelId { get; set; }
    }

    public class PatchVehicleVariantDto
    {
        public string? Name { get; set; }
        public Guid? VehicleModelId { get; set; }
    }
}
