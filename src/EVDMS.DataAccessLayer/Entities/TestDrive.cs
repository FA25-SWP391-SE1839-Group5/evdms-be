using EVDMS.Common.Enums;

namespace EVDMS.DataAccessLayer.Entities
{
    public class TestDrive : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid DealerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public TestDriveStatus Status { get; set; }

        public Customer Customer { get; set; } = null!;
        public Dealer Dealer { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;

        public static readonly string[] SearchableColumns =
        [
            "CustomerId",
            "DealerId",
            "VehicleId",
            "ScheduledAt",
            "Status",
        ];
    }
}
