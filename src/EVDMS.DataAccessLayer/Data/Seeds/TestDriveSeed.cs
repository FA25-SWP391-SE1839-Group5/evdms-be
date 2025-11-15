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
                // Saigon Auto Hub (DealerId:30000000-0000-0000-0000-000000000002)
                new TestDrive
                {
                    Id = Guid.Parse("B0000000-0000-0000-0000-000000000003"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000004"),
                    ScheduledAt = DateTime.SpecifyKind(
                        DateTime.Parse("2024-06-10T10:00:00", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = TestDriveStatus.Canceled,
                },
                // Hanoi EV Center (DealerId:30000000-0000-0000-0000-000000000003)
                new TestDrive
                {
                    Id = Guid.Parse("B0000000-0000-0000-0000-000000000004"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000007"),
                    ScheduledAt = DateTime.SpecifyKind(
                        DateTime.Parse("2026-07-12T11:00:00", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = TestDriveStatus.Scheduled,
                },
                // Da Nang Green Motors (DealerId:30000000-0000-0000-0000-000000000004)
                new TestDrive
                {
                    Id = Guid.Parse("B0000000-0000-0000-0000-000000000005"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000012"),
                    ScheduledAt = DateTime.SpecifyKind(
                        DateTime.Parse("2024-08-15T15:00:00", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = TestDriveStatus.NoShow,
                },
            ];
    }
}
