using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class QuotationDto
    {
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public QuotationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateQuotationDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required decimal TotalAmount { get; set; }

        [Required]
        public required QuotationStatus Status { get; set; }
    }

    public class UpdateQuotationDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required decimal TotalAmount { get; set; }

        [Required]
        public required QuotationStatus Status { get; set; }
    }

    public class PatchQuotationDto
    {
        public Guid? DealerId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public QuotationStatus? Status { get; set; }
    }
}
