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

    public class SalesOrderSummaryDto
    {
        public Guid SalesOrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
        public bool IsFullyPaid { get; set; }
    }

    public class DealerStaffSalesReportDto
    {
        public Guid StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class DealerTotalSalesReportDto
    {
        public Guid DealerId { get; set; }
        public string DealerName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class RegionSalesReportDto
    {
        public string Region { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
