using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerPaymentSeed
    {
        public static List<DealerPayment> DealerPayments
        {
            get
            {
                var orders = DealerOrderSeed.DealerOrders;
                var payments = new List<DealerPayment>();
                var rand = new Random(42);
                int paymentId = 1;
                foreach (var order in orders)
                {
                    decimal total = order.Quantity * 10000m;
                    var daysOffset = rand.Next(1, 61);
                    var secondsOffset = rand.Next(0, 86400);
                    var paymentCreatedAt = order
                        .CreatedAt.AddDays(daysOffset)
                        .AddSeconds(secondsOffset);
                    payments.Add(
                        new DealerPayment
                        {
                            Id = Guid.Parse(
                                $"50000000-0000-0000-0000-{paymentId.ToString().PadLeft(12, '0')}"
                            ),
                            DealerOrderId = order.Id,
                            Amount = total,
                            Status = DealerPaymentStatus.Paid,
                            CreatedAt = paymentCreatedAt,
                            DocumentUrl =
                                "https://res.cloudinary.com/dchtww9gf/raw/upload/v1761118667/EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                            DocumentPublicId =
                                "EVDMS/DealerPaymentDocuments/seed-receipt_s7la38.pdf",
                        }
                    );
                    paymentId++;
                }
                return payments;
            }
        }
    }
}
