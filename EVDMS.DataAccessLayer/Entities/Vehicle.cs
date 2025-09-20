using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid ColorId { get; set; }
        public required string Vin { get; set; }
        public VehicleStatus Status { get; set; }

        public VehicleVariant VehicleVariant { get; set; } = null!;
        public VehicleColor VehicleColor { get; set; } = null!;
        public ICollection<OemInventory> OemInventories { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<TestDrive> TestDrives { get; set; } = [];
        public ICollection<DealerAllocation> DealerAllocations { get; set; } = [];
    }
}
