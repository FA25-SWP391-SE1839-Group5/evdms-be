using System.Globalization;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class PaymentSeed
    {
        public static List<Payment> Payments =>
            [
                new Payment
                {
                    Id = Guid.Parse("A0000000-0000-0000-0000-000000000001"),
                    SalesOrderId = Guid.Parse("90000000-0000-0000-0000-000000000001"),
                    Amount = 500000m,
                    Date = DateTime.SpecifyKind(
                        DateTime.Parse("2024-04-02", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Method = PaymentMethod.BankTransfer,
                },
                new Payment
                {
                    Id = Guid.Parse("A0000000-0000-0000-0000-000000000002"),
                    SalesOrderId = Guid.Parse("90000000-0000-0000-0000-000000000002"),
                    Amount = 750000m,
                    Date = DateTime.SpecifyKind(
                        DateTime.Parse("2024-05-02", CultureInfo.InvariantCulture),
                        DateTimeKind.Utc
                    ),
                    Method = PaymentMethod.Cash,
                },
            ];
    }
}
