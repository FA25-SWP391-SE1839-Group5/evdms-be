using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Payment : BaseEntity
    {
        public Guid SalesOrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod Method { get; set; }

        public SalesOrder SalesOrder { get; set; } = null!;
    }
}
