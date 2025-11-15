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
                int totalDays = 730; // 2 years

                for (int i = 0; i < totalDays; i++)
                {
                    foreach (var variant in variants)
                    {
                        // Simulate a trend (e.g., demand increases over time)
                        double trend = 10 + (i * 0.05);

                        // Simulate seasonality (e.g., yearly cycle)
                        double seasonality = 20 * Math.Sin(2 * Math.PI * i / 365);

                        // Add some random noise
                        double noise = rand.NextDouble() * 10 - 5; // -2 to +2

                        // Add random spikes and dips
                        double spikeOrDip = 0;
                        double chance = rand.NextDouble();
                        if (chance < 0.01) // 1% chance for a spike
                            spikeOrDip = rand.Next(10, 21); // spike: +10 to +20
                        else if (chance > 0.99) // 1% chance for a dip
                            spikeOrDip = -rand.Next(10, 21); // dip: -10 to -20

                        int quantity = (int)
                            Math.Max(1, Math.Round(trend + seasonality + noise + spikeOrDip));

                        var dealer = dealers[rand.Next(dealers.Length)];
                        var color = colors[rand.Next(colors.Length)];
                        var createdAt = startDate.AddDays(i).AddSeconds(rand.Next(0, 86400));

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
                }
                return orders;
            }
        }
    }
}
