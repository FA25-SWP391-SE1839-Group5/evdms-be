namespace EVDMS.DataAccessLayer.Entities
{
    public class CustomerDealer : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }

        public required Customer Customer { get; set; }
        public required Dealer Dealer { get; set; }
    }
}