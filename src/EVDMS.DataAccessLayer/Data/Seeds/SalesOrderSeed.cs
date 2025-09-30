using System.Globalization;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class SalesOrderSeed
    {
        public static List<SalesOrder> SalesOrders =>
            [
                new SalesOrder
                {
                    Id = Guid.Parse("90000000-0000-0000-0000-000000000001"),
                    QuotationId = Guid.Parse("70000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000001"),
                    Date = DateTime.SpecifyKind(
                        DateTime.Parse("2024-04-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = SalesOrderStatus.Pending,
                },
                new SalesOrder
                {
                    Id = Guid.Parse("90000000-0000-0000-0000-000000000002"),
                    QuotationId = Guid.Parse("70000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    VehicleId = Guid.Parse("80000000-0000-0000-0000-000000000002"),
                    Date = DateTime.SpecifyKind(
                        DateTime.Parse("2024-05-01", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Status = SalesOrderStatus.Confirmed,
                },
            ];
    }
}
