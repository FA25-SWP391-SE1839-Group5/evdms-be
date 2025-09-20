namespace EVDMS.DataAccessLayer.Entities
{
    public class CustomerDealer : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }

        public Customer Customer { get; set; } = null!;
        public Dealer Dealer { get; set; } = null!;
    }
}
