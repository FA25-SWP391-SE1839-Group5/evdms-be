namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerContract : BaseEntity
    {
        public Guid DealerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalesTarget { get; set; }
        public decimal OutstandingDebt { get; set; }

        public required Dealer Dealer { get; set; }
    }
}
