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
        public required Guid VariantId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        [MinLength(11)]
        public required string Vin { get; set; }

        [Required]
        public required VehicleColor Color { get; set; }

        [Required]
        public required VehicleType Type { get; set; }

        [Required]
        public required VehicleStatus Status { get; set; }
    }

    public class UpdateVehicleDto
    {
        [Required]
        public required Guid VariantId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        [MinLength(11)]
        public required string Vin { get; set; }

        [Required]
        public required VehicleColor Color { get; set; }

        [Required]
        public required VehicleType Type { get; set; }

        [Required]
        public required VehicleStatus Status { get; set; }
    }

    public class PatchVehicleDto
    {
        public Guid? VariantId { get; set; }

        public Guid? DealerId { get; set; }

        public string? Vin { get; set; }

        public VehicleColor? Color { get; set; }

        public VehicleType? Type { get; set; }

        public VehicleStatus? Status { get; set; }
    }
}
