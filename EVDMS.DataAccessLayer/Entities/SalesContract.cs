namespace EVDMS.DataAccessLayer.Entities
{
    public class SalesContract : BaseEntity
    {
        public Guid SalesOrderId { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal TotalAmount { get; set; }

        public SalesOrder SalesOrder { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = [];
    }
}
