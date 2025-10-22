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
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    Amount = 114000m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
            ];
    }
}
