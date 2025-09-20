using System.Collections.Generic;
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
        public SalesOrderStatus Status { get; set; }

        public required Quotation Quotation { get; set; }
        public required Dealer Dealer { get; set; }
        public required User User { get; set; }
        public required Customer Customer { get; set; }
        public required Vehicle Vehicle { get; set; }
        public ICollection<SalesContract> SalesContracts { get; set; } = [];
    }
}