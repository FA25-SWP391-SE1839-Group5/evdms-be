namespace EVDMS.DataAccessLayer.Entities
{
    public class Promotion : BaseEntity
    {
        public Guid DealerId { get; set; }
        public required string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public required Dealer Dealer { get; set; }
    }
}
