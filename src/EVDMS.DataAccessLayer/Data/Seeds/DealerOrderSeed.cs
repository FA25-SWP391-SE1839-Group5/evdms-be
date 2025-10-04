using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DealerOrderSeed
    {
        public static List<DealerOrder> DealerOrders =>
            [
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Quantity = 5,
                    Color = VehicleColor.White,
                    Status = DealerOrderStatus.Pending,
                },
                new DealerOrder
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Quantity = 2,
                    Color = VehicleColor.Black,
                    Status = DealerOrderStatus.Confirmed,
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
            ];
    }
}
