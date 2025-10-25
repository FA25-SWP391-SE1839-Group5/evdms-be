using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class SalesOrder : BaseEntity
    {
        public Guid QuotationId { get; set; }
        public Guid DealerId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime Date { get; set; }
        public SalesOrderStatus Status { get; set; }

        public Quotation Quotation { get; set; } = null!;
        public Dealer Dealer { get; set; } = null!;
        public User User { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = [];

        public static readonly string[] SearchableColumns =
        [
            "QuotationId",
            "DealerId",
            "UserId",
            "CustomerId",
            "VehicleId",
            "Date",
            "Status",
        ];
    }
}
