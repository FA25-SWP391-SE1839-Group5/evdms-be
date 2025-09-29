using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class QuotationDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateQuotationDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required decimal Price { get; set; }
    }

    public class UpdateQuotationDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required decimal Price { get; set; }
    }

    public class PatchQuotationDto
    {
        public Guid? CustomerId { get; set; }
        public Guid? DealerId { get; set; }
        public decimal? Price { get; set; }
    }
}
