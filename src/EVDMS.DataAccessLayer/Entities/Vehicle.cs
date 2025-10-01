using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid VariantId { get; set; }
        public Guid DealerId { get; set; }
        public required string Vin { get; set; }
        public VehicleColor Color { get; set; }
        public VehicleType Type { get; set; }
        public VehicleStatus Status { get; set; }

        public VehicleVariant VehicleVariant { get; set; } = null!;
        public Dealer Dealer { get; set; } = null!;
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<TestDrive> TestDrives { get; set; } = [];

        public static readonly string[] SearchableColumns =
        [
            "VariantId",
            "DealerId",
            "Vin",
            "Color",
            "Type",
            "Status",
        ];
    }
}
