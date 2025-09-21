using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleVariantSeed
    {
        public static List<VehicleVariant> VehicleVariants =>
            [
                // Honda Civic
                new VehicleVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    ModelId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    VariantName = "Honda Civic LX",
                    BasePrice = 22000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    ModelId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    VariantName = "Honda Civic Sport",
                    BasePrice = 24000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111103"),
                    ModelId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    VariantName = "Honda Civic EX",
                    BasePrice = 26000,
                },
                // Honda Accord
                new VehicleVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    ModelId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    VariantName = "Honda Accord LX",
                    BasePrice = 27000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                    ModelId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    VariantName = "Honda Accord Sport",
                    BasePrice = 29000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                    ModelId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    VariantName = "Honda Accord EX-L",
                    BasePrice = 32000,
                },
                // Toyota Corolla
                new VehicleVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333301"),
                    ModelId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    VariantName = "Toyota Corolla L",
                    BasePrice = 21000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333302"),
                    ModelId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    VariantName = "Toyota Corolla LE",
                    BasePrice = 23000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333303"),
                    ModelId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    VariantName = "Toyota Corolla XSE",
                    BasePrice = 25000,
                },
                // Toyota Camry
                new VehicleVariant
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444401"),
                    ModelId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    VariantName = "Toyota Camry LE",
                    BasePrice = 25000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444402"),
                    ModelId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    VariantName = "Toyota Camry SE",
                    BasePrice = 27000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444403"),
                    ModelId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    VariantName = "Toyota Camry XLE",
                    BasePrice = 31000,
                },
                // Tesla Model 3
                new VehicleVariant
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555501"),
                    ModelId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    VariantName = "Tesla Model 3 RWD",
                    BasePrice = 40000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555502"),
                    ModelId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    VariantName = "Tesla Model 3 Long Range",
                    BasePrice = 47000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555503"),
                    ModelId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    VariantName = "Tesla Model 3 Performance",
                    BasePrice = 54000,
                },
                // Tesla Model S
                new VehicleVariant
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666601"),
                    ModelId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    VariantName = "Tesla Model S Dual Motor",
                    BasePrice = 90000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666602"),
                    ModelId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    VariantName = "Tesla Model S Plaid",
                    BasePrice = 110000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666603"),
                    ModelId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    VariantName = "Tesla Model S Long Range",
                    BasePrice = 100000,
                },
                // Toyota RAV4
                new VehicleVariant
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777701"),
                    ModelId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    VariantName = "Toyota RAV4 LE",
                    BasePrice = 27000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777702"),
                    ModelId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    VariantName = "Toyota RAV4 XLE",
                    BasePrice = 30000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777703"),
                    ModelId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    VariantName = "Toyota RAV4 Limited",
                    BasePrice = 35000,
                },
                // Honda CR-V
                new VehicleVariant
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888801"),
                    ModelId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    VariantName = "Honda CR-V LX",
                    BasePrice = 28000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888802"),
                    ModelId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    VariantName = "Honda CR-V EX",
                    BasePrice = 32000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888803"),
                    ModelId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    VariantName = "Honda CR-V Touring",
                    BasePrice = 37000,
                },
                // Ford F-150
                new VehicleVariant
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999901"),
                    ModelId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    VariantName = "Ford F-150 XL",
                    BasePrice = 32000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999902"),
                    ModelId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    VariantName = "Ford F-150 XLT",
                    BasePrice = 37000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999903"),
                    ModelId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    VariantName = "Ford F-150 Lariat",
                    BasePrice = 45000,
                },
                // Ford Mustang
                new VehicleVariant
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    ModelId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    VariantName = "Ford Mustang EcoBoost",
                    BasePrice = 28000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"),
                    ModelId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    VariantName = "Ford Mustang GT",
                    BasePrice = 40000,
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa03"),
                    ModelId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    VariantName = "Ford Mustang Mach 1",
                    BasePrice = 53000,
                },
            ];
    }
}
