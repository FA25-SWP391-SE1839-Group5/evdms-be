using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrder : BaseEntity
    {
        public Guid DealerId { get; set; }
        public DealerOrderStatus Status { get; set; }

        public required Dealer Dealer { get; set; }
        public ICollection<DealerOrderItem> DealerOrderItems { get; set; } = [];
    }
}
