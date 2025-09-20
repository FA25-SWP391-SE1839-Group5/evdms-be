using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Quotation : BaseEntity
    {
        public Guid DealerId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public QuotationStatus Status { get; set; }

        public Dealer Dealer { get; set; } = null!;
        public User User { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
    }
}
