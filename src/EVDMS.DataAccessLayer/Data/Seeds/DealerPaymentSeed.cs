using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerPaymentSeed
    {
        public static List<DealerPayment> DealerPayments =>
            [
                // EV Motors Saigon
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    Amount = 41967m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    Amount = 51300m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    Amount = 49491m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                // Saigon Auto Hub
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                    Amount = 83934m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    Amount = 51300m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                // Hanoi EV Center
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                    Amount = 153900m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
                // Da Nang Green Motors
                new DealerPayment
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    DealerOrderId = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                    Amount = 49491m,
                    Status = DealerPaymentStatus.Paid,
                    DocumentUrl =
                        "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                    DocumentPublicId = "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                },
            ];
    }
}
