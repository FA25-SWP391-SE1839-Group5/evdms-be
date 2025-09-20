using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerAllocation : BaseEntity
    {
        public Guid DealerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DealerAllocationStatus Status { get; set; }

        public Dealer Dealer { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
    }
}
