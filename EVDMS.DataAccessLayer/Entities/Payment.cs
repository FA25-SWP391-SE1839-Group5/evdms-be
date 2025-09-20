using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Payment : BaseEntity
    {
        public Guid SalesContractId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod Method { get; set; }

        public required SalesContract SalesContract { get; set; }
    }
}