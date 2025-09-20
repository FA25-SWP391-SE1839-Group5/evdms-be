using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleModelSeed
    {
        public static List<VehicleModel> VehicleModels =>
            [
                new VehicleModel
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ModelName = "Honda Civic",
                    Description =
                        "A reliable and fuel-efficient compact sedan, popular for daily commuting and sporty handling.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ModelName = "Honda Accord",
                    Description =
                        "A spacious midsize sedan known for its comfort, advanced safety features, and smooth ride.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    ModelName = "Toyota Corolla",
                    Description =
                        "A globally best-selling compact sedan, recognized for its durability and low maintenance costs.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    ModelName = "Toyota Camry",
                    Description =
                        "A refined midsize sedan offering a quiet cabin, strong resale value, and hybrid options.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    ModelName = "Tesla Model 3",
                    Description =
                        "A cutting-edge electric sedan with impressive acceleration, range, and advanced technology.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    ModelName = "Tesla Model S",
                    Description =
                        "A luxury electric sedan featuring long range, high performance, and innovative autopilot features.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    ModelName = "Toyota RAV4",
                    Description =
                        "A versatile compact SUV with available all-wheel drive, ample cargo space, and hybrid variants.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    ModelName = "Honda CR-V",
                    Description =
                        "A family-friendly compact SUV known for its roomy interior, reliability, and efficient engines.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    ModelName = "Ford F-150",
                    Description =
                        "America's best-selling full-size pickup truck, renowned for its towing capacity and ruggedness.",
                },
                new VehicleModel
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    ModelName = "Ford Mustang",
                    Description =
                        "An iconic sports car offering powerful engine options and classic American muscle styling.",
                },
            ];
    }
}
