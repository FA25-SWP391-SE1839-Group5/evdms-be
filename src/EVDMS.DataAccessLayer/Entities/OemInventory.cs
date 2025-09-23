using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class OemInventory : BaseEntity
    {
        public Guid VehicleId { get; set; }
        public OemInventoryLocation Location { get; set; }
        public OemInventoryStatus Status { get; set; }

        public Vehicle Vehicle { get; set; } = null!;
    }
}
