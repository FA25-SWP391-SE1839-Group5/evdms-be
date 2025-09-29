using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleSeed
    {
        public static List<Vehicle> Vehicles =>
            [
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJYGDEE8LF000001",
                    Color = VehicleColor.White,
                    Type = VehicleType.Sale,
                    Status = VehicleStatus.Available,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJYGDEE8LF000002",
                    Color = VehicleColor.Black,
                    Type = VehicleType.Display,
                    Status = VehicleStatus.Reserved,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000003"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJ3E1EA7LF000003",
                    Color = VehicleColor.Blue,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Reserved,
                },
            ];
    }
}
