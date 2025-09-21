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
                    Id = VehicleModelIds.HyundaiIoniq5,
                    ModelName = "Hyundai Ioniq 5",
                    Description =
                        "A distinctive battery-electric compact crossover SUV, notable for its retro-futuristic design and being built on Hyundai's Electric Global Modular Platform (E-GMP) with 800V charging capability.",
                    Year = 2021,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450493/Hyundai_Ioniq_5_f5npjl.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.FordMustangMachE,
                    ModelName = "Ford Mustang Mach-E",
                    Description =
                        "A battery-electric compact crossover SUV that draws design and naming inspiration from the Mustang line, offering a mix of sporty performance and SUV practicality.",
                    Year = 2020,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Ford_Mustang_Mach-E_cdvi8o.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.KiaEv6,
                    ModelName = "Kia EV6",
                    Description =
                        "A battery-electric compact crossover SUV, closely related to the Hyundai Ioniq 5 as it also uses the E-GMP platform, known for its sleek, crossover-coupe styling and fast charging.",
                    Year = 2021,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450487/Kia_EV6_boehy3.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.ChevroletBlazerEv,
                    ModelName = "Chevrolet Blazer EV",
                    Description =
                        "A battery-electric mid-size crossover SUV built on the GM Ultium platform, offering a sporty design and multiple drivetrain configurations (FWD, RWD, AWD).",
                    Year = 2023,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450486/Chevrolet_Blazer_EV_v6t9tq.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.LucidAir,
                    ModelName = "Lucid Air",
                    Description =
                        "A battery-electric four-door luxury sedan known for its focus on maximum driving range, spacious interior packaging, and high-performance capabilities, produced by a Silicon Valley startup.",
                    Year = 2021,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450488/Lucid_Air_nur4uz.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.NissanAriya,
                    ModelName = "Nissan Ariya",
                    Description =
                        "A battery-electric compact crossover SUV that serves as Nissan's first dedicated zero-emissions SUV, featuring a modern, sleek design and available dual-motor e-4ORCE all-wheel drive.",
                    Year = 2022,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450488/Nissan_Ariya_ds6ta3.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.PorscheTaycan,
                    ModelName = "Porsche Taycan",
                    Description =
                        "Porsche's first all-electric production vehicle, a high-performance luxury sports sedan (and shooting brake) known for its rapid acceleration, precise handling, and 800-volt electrical architecture.",
                    Year = 2019,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450489/Porsche_Taycan_q2esmf.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.BmwI4,
                    ModelName = "BMW i4",
                    Description =
                        "A battery-electric compact executive car with a five-door liftback body style, closely related to the gasoline-powered BMW 4 Series Gran Coupé and offering a balance of luxury and performance.",
                    Year = 2021,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450487/BMW_i4_fackc5.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.TeslaModelY,
                    ModelName = "Tesla Model Y",
                    Description =
                        "A battery-electric compact crossover SUV that shares many components with the Model 3, offering more utility, a higher seating position, and optional three-row seating.",
                    Year = 2020,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450497/Tesla_Model_Y_m9txrs.jpg",
                },
                new VehicleModel
                {
                    Id = VehicleModelIds.TeslaModel3,
                    ModelName = "Tesla Model 3",
                    Description =
                        "A battery-electric mid-size sedan with a fastback body style, marketed as a more affordable electric vehicle than Tesla's previous models.",
                    Year = 2017,
                    ImageUrl =
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Tesla_Model_3_evqd0p.jpg",
                },
            ];
    }
}
