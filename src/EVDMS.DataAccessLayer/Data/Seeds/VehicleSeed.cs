using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleSeed
    {
        public static List<Vehicle> Vehicles =>
            [
                // EV Motors Saigon
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000001"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJDC63CXSA000001",
                    Color = VehicleColor.White,
                    Type = VehicleType.Sale,
                    Status = VehicleStatus.Reserved,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000002"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJDC5AEXSA000001",
                    Color = VehicleColor.Black,
                    Type = VehicleType.Sale,
                    Status = VehicleStatus.Sold,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000003"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Vin = "5YJDCDA0XSA000001",
                    Color = VehicleColor.Red,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Reserved,
                },
                // Saigon Auto Hub (DealerId:30000000-0000-0000-0000-000000000002)
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000004"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Vin = "5YJDC63CXSA000002",
                    Color = VehicleColor.Silver,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Available,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000005"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Vin = "5YJDC63CXSA000003",
                    Color = VehicleColor.Silver,
                    Type = VehicleType.Display,
                    Status = VehicleStatus.Reserved,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000006"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Vin = "5YJDCDA0XSA000002",
                    Color = VehicleColor.Yellow,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Reserved,
                },
                // Hanoi EV Center (DealerId:30000000-0000-0000-0000-000000000003)
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000007"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Vin = "5YJDC5AEXSA000002",
                    Color = VehicleColor.Gray,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Reserved,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000008"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Vin = "5YJDC5AEXSA000003",
                    Color = VehicleColor.Gray,
                    Type = VehicleType.Sale,
                    Status = VehicleStatus.Available,
                },
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000009"),
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Vin = "5YJDC5AEXSA000004",
                    Color = VehicleColor.Gray,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Reserved,
                },
                // Da Nang Green Motors (DealerId:30000000-0000-0000-0000-000000000004)
                new Vehicle
                {
                    Id = Guid.Parse("80000000-0000-0000-0000-000000000012"),
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    DealerId = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Vin = "5YJDCDA0XSA000004",
                    Color = VehicleColor.Green,
                    Type = VehicleType.Demo,
                    Status = VehicleStatus.Available,
                },
            ];
    }
}
