using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid DealerId { get; set; }
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
