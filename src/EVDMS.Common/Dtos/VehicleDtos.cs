using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }
        public Guid DealerId { get; set; }
        public string Vin { get; set; } = string.Empty;
        public VehicleColor Color { get; set; }
        public VehicleType Type { get; set; }
        public VehicleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVehicleDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required Guid DealerId { get; set; }
    }

    public class UpdateVehicleDto
    {
        [Required]
        public required string Name { get; set; } = string.Empty;

        [Required]
        public required Guid DealerId { get; set; }
    }

    public class PatchVehicleDto
    {
        public string? Name { get; set; }
        public Guid? DealerId { get; set; }
    }
}
