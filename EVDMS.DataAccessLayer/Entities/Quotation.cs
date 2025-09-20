using System.Collections.Generic;
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

        public required Dealer Dealer { get; set; }
        public required User User { get; set; }
        public required Customer Customer { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
    }
}
