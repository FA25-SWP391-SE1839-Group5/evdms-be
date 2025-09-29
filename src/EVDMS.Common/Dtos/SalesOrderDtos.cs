using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class SalesOrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateSalesOrderDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required decimal TotalAmount { get; set; }
    }

    public class UpdateSalesOrderDto
    {
        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required decimal TotalAmount { get; set; }
    }

    public class PatchSalesOrderDto
    {
        public Guid? CustomerId { get; set; }
        public Guid? DealerId { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
