using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleModelSeed
    {
        public static List<VehicleModel> VehicleModels =>
            [
                new VehicleModel
                {
                    Id = VehicleModelIds.TeslaModelY,
                    Name = "Tesla Model Y",
                    Description =
                        "A battery-electric compact crossover SUV that shares many components with the Model 3, offering more utility, a higher seating position, and optional three-row seating.",
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450497/Tesla_Model_Y_m9txrs.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.TeslaModel3,
                    Name = "Tesla Model 3",
                    Description =
                        "A battery-electric mid-size sedan with a fastback body style, marketed as a more affordable electric vehicle than Tesla's previous models.",
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Tesla_Model_3_evqd0p.jpg",
                },
            ];
    }
}
