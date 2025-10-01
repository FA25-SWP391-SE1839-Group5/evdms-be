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
            ];
    }
}
