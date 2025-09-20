namespace EVDMS.DataAccessLayer.Entities
{
    public class SalesContract : BaseEntity
    {
        public Guid SalesOrderId { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal TotalAmount { get; set; }

        public required SalesOrder SalesOrder { get; set; }
        public ICollection<Payment> Payments { get; set; } = [];
    }
}