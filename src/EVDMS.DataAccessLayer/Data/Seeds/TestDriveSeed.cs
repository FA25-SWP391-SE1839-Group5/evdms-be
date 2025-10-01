using System.Globalization;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class TestDriveSeed
    {
        public static List<TestDrive> TestDrives =>
            [
                new TestDrive
                {
                    Id = Guid.Parse("B0000000-0000-0000-0000-000000000001"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000001"),
                    ScheduledAt = DateTime.SpecifyKind(
                        DateTime.Parse("2024-04-10T09:00:00", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = TestDriveStatus.Scheduled,
                },
                new TestDrive
                {
                    Id = Guid.Parse("B0000000-0000-0000-0000-000000000002"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000002"),
                    ScheduledAt = DateTime.SpecifyKind(
                        DateTime.Parse("2024-05-15T14:00:00", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = TestDriveStatus.Completed,
                },
            ];
    }
}
