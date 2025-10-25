using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerOrderSeed
    {
        public static List<DealerOrder> DealerOrders =>
            [
                // EV Motors Saigon
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Quantity = 1,
                    Color = VehicleColor.White,
                    Status = DealerOrderStatus.Delivered,
                },
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Quantity = 1,
                    Color = VehicleColor.Black,
                    Status = DealerOrderStatus.Delivered,
                },
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    Quantity = 1,
                    Color = VehicleColor.Red,
                    Status = DealerOrderStatus.Delivered,
                },
                // Saigon Auto Hub
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Quantity = 2,
                    Color = VehicleColor.Silver,
                    Status = DealerOrderStatus.Delivered,
                },
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    Quantity = 1,
                    Color = VehicleColor.Yellow,
                    Status = DealerOrderStatus.Delivered,
                },
                // Hanoi EV Center
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Quantity = 3,
                    Color = VehicleColor.Gray,
                    Status = DealerOrderStatus.Delivered,
                },
                // Da Nang Green Motors
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    Quantity = 1,
                    Color = VehicleColor.Green,
                    Status = DealerOrderStatus.Delivered,
                },
            ];
    }
}
