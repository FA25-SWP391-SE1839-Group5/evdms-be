using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class PromotionDto
    {
        public Guid Id { get; set; }
        public Guid? DealerId { get; set; }
        public PromotionType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreatePromotionDto
    {
        public Guid? DealerId { get; set; }

        [Required]
        public required PromotionType Type { get; set; }

        [Required]
        public required string Description { get; set; }

        [Range(0, 100)]
        public required decimal DiscountPercent { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }
    }

    public class UpdatePromotionDto
    {
        public Guid? DealerId { get; set; }

        [Required]
        public required PromotionType Type { get; set; }

        [Required]
        public required string Description { get; set; }

        [Range(0, 100)]
        public required decimal DiscountPercent { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }
    }

    public class PatchPromotionDto
    {
        public Guid? DealerId { get; set; }
        public PromotionType? Type { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
