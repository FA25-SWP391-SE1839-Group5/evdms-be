using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerOrder : BaseEntity
    {
        public Guid DealerId { get; set; }
        public DealerOrderStatus Status { get; set; }

        public Dealer Dealer { get; set; } = null!;
        public ICollection<DealerOrderItem> DealerOrderItems { get; set; } = [];
    }
}
