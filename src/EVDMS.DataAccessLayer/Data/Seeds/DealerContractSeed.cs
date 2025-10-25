using System.Globalization;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerContractSeed
    {
        public static List<DealerContract> DealerContracts =>
            [
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 1000000m,
                    OutstandingDebt = 50000m,
                },
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2025-11-30", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 750000m,
                    OutstandingDebt = 25000m,
                },
                // Saigon Auto Hub (DealerId:30000000-0000-0000-0000-000000000002)
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2023-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 800000m,
                    OutstandingDebt = 10000m,
                },
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2026-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 900000m,
                    OutstandingDebt = 20000m,
                },
                // Hanoi EV Center (DealerId:30000000-0000-0000-0000-000000000003)
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2022-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 700000m,
                    OutstandingDebt = 5000m,
                },
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-03-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2025-12-28", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 950000m,
                    OutstandingDebt = 15000m,
                },
                // Da Nang Green Motors (DealerId:30000000-0000-0000-0000-000000000004)
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2021-01-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2021-12-31", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 600000m,
                    OutstandingDebt = 3000m,
                },
                new DealerContract
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    StartDate = DateTime.SpecifyKind(
                        DateTime.Parse("2024-05-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    EndDate = DateTime.SpecifyKind(
                        DateTime.Parse("2028-04-30", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    SalesTarget = 850000m,
                    OutstandingDebt = 12000m,
                },
            ];
    }
}
