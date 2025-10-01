using System.ComponentModel.DataAnnotations;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Dtos
{
    public class SalesOrderDto
    {
        public Guid Id { get; set; }
        public Guid QuotationId { get; set; }
        public Guid DealerId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime Date { get; set; }
        public SalesOrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateSalesOrderDto
    {
        [Required]
        public required Guid QuotationId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid VehicleId { get; set; }

        [Required]
        public required DateTime Date { get; set; }

        [Required]
        public required SalesOrderStatus Status { get; set; }
    }

    public class UpdateSalesOrderDto
    {
        [Required]
        public required Guid QuotationId { get; set; }

        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public required Guid CustomerId { get; set; }

        [Required]
        public required Guid VehicleId { get; set; }

        [Required]
        public required DateTime Date { get; set; }

        [Required]
        public required SalesOrderStatus Status { get; set; }
    }

    public class PatchSalesOrderDto
    {
        public Guid? QuotationId { get; set; }

        public Guid? DealerId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? VehicleId { get; set; }

        public DateTime? Date { get; set; }

        public SalesOrderStatus? Status { get; set; }
    }
}
