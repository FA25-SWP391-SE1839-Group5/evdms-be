using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class DealerPaymentDto
    {
        public Guid Id { get; set; }
        public Guid DealerOrderId { get; set; }
        public decimal Amount { get; set; }
        public DealerPaymentStatus Status { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateDealerPaymentDto
    {
        [Required]
        public Guid DealerOrderId { get; set; }
    }

    public class UpdateDealerPaymentDto
    {
        [Required]
        public Guid DealerOrderId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DealerPaymentStatus Status { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
    }

    public class PatchDealerPaymentDto
    {
        public Guid? DealerOrderId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }
        public DealerPaymentStatus? Status { get; set; }
        public string? PaymentIntentId { get; set; }
    }
}
