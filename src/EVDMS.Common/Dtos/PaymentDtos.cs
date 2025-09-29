using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid SalesOrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreatePaymentDto
    {
        [Required]
        public required Guid SalesOrderId { get; set; }

        [Required]
        public required decimal Amount { get; set; }
    }

    public class UpdatePaymentDto
    {
        [Required]
        public required Guid SalesOrderId { get; set; }

        [Required]
        public required decimal Amount { get; set; }
    }

    public class PatchPaymentDto
    {
        public Guid? SalesOrderId { get; set; }
        public decimal? Amount { get; set; }
    }
}
