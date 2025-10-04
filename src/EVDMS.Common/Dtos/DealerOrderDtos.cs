using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class DealerOrderDto
    {
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public Guid VariantId { get; set; }
        public int Quantity { get; set; }
        public VehicleColor Color { get; set; }
        public DealerOrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateDealerOrderDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid VariantId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int Quantity { get; set; }

        [Required]
        public required VehicleColor Color { get; set; }

        [Required]
        public required DealerOrderStatus Status { get; set; }
    }

    public class UpdateDealerOrderDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid VariantId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int Quantity { get; set; }

        [Required]
        public required VehicleColor Color { get; set; }

        [Required]
        public required DealerOrderStatus Status { get; set; }
    }

    public class PatchDealerOrderDto
    {
        public Guid? DealerId { get; set; }
        public Guid? VariantId { get; set; }
        public int? Quantity { get; set; }
        public VehicleColor? Color { get; set; }
        public DealerOrderStatus? Status { get; set; }
    }
}
