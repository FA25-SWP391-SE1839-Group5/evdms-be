using System;
using System.Collections.Generic;
using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid ColorId { get; set; }
        public required string Vin { get; set; }
        public VehicleStatus Status { get; set; }

        public required VehicleVariant VehicleVariant { get; set; }
        public required VehicleColor VehicleColor { get; set; }
        public ICollection<OemInventory> OemInventories { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<TestDrive> TestDrives { get; set; } = [];
        public ICollection<DealerAllocation> DealerAllocations { get; set; } = [];
    }
}