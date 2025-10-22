using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerPaymentSeed
    {
        public static List<DealerPayment> DealerPayments =>
            [
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    Amount = 233150m,
                    Status = DealerPaymentStatus.Pending,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1761107830/seed-receipt_sacyig.pdf",
                },
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    Amount = 114000m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1761107830/seed-receipt_sacyig.pdf",
                },
            ];
    }
}
