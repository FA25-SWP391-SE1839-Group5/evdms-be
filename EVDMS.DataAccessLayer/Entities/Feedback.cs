using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Feedback : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public required string Content { get; set; }
        public FeedbackStatus Status { get; set; }

        public Customer Customer { get; set; } = null!;
        public Dealer Dealer { get; set; } = null!;
    }
}
