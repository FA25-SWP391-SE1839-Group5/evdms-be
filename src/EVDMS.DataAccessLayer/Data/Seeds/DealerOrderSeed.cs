using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerOrderSeed
    {
        public static List<DealerOrder> DealerOrders
        {
            get
            {
                var dealers = new[]
                {
                    Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Guid.Parse("30000000-0000-0000-0000-000000000004"),
                };
                var variants = new[]
                {
                    Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Guid.Parse("22222222-2222-2222-2222-222222222201"),
                };
                var colors = (VehicleColor[])Enum.GetValues(typeof(VehicleColor));
                var orders = new List<DealerOrder>();
                var rand = new Random(42);
                var startDate = DateTime.UtcNow.AddYears(-2);
                int orderId = 1;
                for (int i = 0; i < 500; i++)
                {
                    var dealer = dealers[rand.Next(dealers.Length)];
                    var variant = variants[rand.Next(variants.Length)];
                    var color = colors[rand.Next(colors.Length)];
                    var quantity = rand.Next(1, 200);
                    var daysOffset = rand.Next(0, 730);
                    var secondsOffset = rand.Next(0, 86400);
                    var createdAt = startDate.AddDays(daysOffset).AddSeconds(secondsOffset);
                    orders.Add(
                        new DealerOrder
                        {
                            Id = Guid.Parse(
                                $"40000000-0000-0000-0000-{orderId.ToString().PadLeft(12, '0')}"
                            ),
                            DealerId = dealer,
                            VariantId = variant,
                            Quantity = quantity,
                            Color = color,
                            Status = DealerOrderStatus.Delivered,
                            CreatedAt = createdAt,
                        }
                    );
                    orderId++;
                }
                return orders;
            }
        }
    }
}
