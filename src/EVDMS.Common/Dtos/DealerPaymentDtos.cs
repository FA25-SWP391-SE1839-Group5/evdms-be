using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace EVDMS.Common.Dtos
{
    public class DealerPaymentDto
    {
        public Guid Id { get; set; }
        public Guid DealerOrderId { get; set; }
        public Guid DealerId { get; set; }
        public string DealerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DealerPaymentStatus Status { get; set; }
        public string? DocumentUrl { get; set; }
        public string? PublicDocumentId { get; set; }
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
        public string? DocumentUrl { get; set; }
        public string? PublicDocumentId { get; set; }
    }

    public class PatchDealerPaymentDto
    {
        public Guid? DealerOrderId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }
        public DealerPaymentStatus? Status { get; set; }
        public string? DocumentUrl { get; set; }
        public string? PublicDocumentId { get; set; }
    }

    public class UploadDealerPaymentDocumentDto
    {
        [Required]
        public IFormFile Document { get; set; } = null!;
    }

    public class UploadDealerPaymentDocumentResponseDto
    {
        public string? DocumentUrl { get; set; }
        public string? PublicDocumentId { get; set; }
    }
}
