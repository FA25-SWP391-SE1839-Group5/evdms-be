using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class DealerAllocation : BaseEntity
    {
        public Guid DealerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DealerAllocationStatus Status { get; set; }

        public required Dealer Dealer { get; set; }
        public required Vehicle Vehicle { get; set; }
    }
}
