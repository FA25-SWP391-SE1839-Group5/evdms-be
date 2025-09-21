using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleVariantSeed
    {
        public static List<VehicleVariant> VehicleVariants =>
            [
                // Hyundai Ioniq 5
                new VehicleVariant
                {
                    Id = VehicleVariantIds.HyundaiIoniq5Se,
                    ModelId = VehicleModelIds.HyundaiIoniq5,
                    VariantName = "Hyundai Ioniq 5 SE (Standard Range RWD)",
                    BasePrice = 42600,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.HyundaiIoniq5Sel,
                    ModelId = VehicleModelIds.HyundaiIoniq5,
                    VariantName = "Hyundai Ioniq 5 SEL (RWD)",
                    BasePrice = 49600,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.HyundaiIoniq5Limited,
                    ModelId = VehicleModelIds.HyundaiIoniq5,
                    VariantName = "Hyundai Ioniq 5 Limited (RWD)",
                    BasePrice = 54300,
                },
                // Ford Mustang Mach-E
                new VehicleVariant
                {
                    Id = VehicleVariantIds.FordMachESelect,
                    ModelId = VehicleModelIds.FordMustangMachE,
                    VariantName = "Ford Mustang Mach-E Select (RWD)",
                    BasePrice = 37995,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.FordMachEPremium,
                    ModelId = VehicleModelIds.FordMustangMachE,
                    VariantName = "Ford Mustang Mach-E Premium (RWD, Standard Range)",
                    BasePrice = 41995,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.FordMachECaliforniaRt1,
                    ModelId = VehicleModelIds.FordMustangMachE,
                    VariantName = "Ford Mustang Mach-E California Route 1",
                    BasePrice = 54000,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.FordMachEGt,
                    ModelId = VehicleModelIds.FordMustangMachE,
                    VariantName = "Ford Mustang Mach-E GT (AWD)",
                    BasePrice = 54495,
                },
                // Kia EV6
                new VehicleVariant
                {
                    Id = VehicleVariantIds.KiaEv6Light,
                    ModelId = VehicleModelIds.KiaEv6,
                    VariantName = "Kia EV6 Light (RWD)",
                    BasePrice = 42900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.KiaEv6Wind,
                    ModelId = VehicleModelIds.KiaEv6,
                    VariantName = "Kia EV6 Wind (RWD)",
                    BasePrice = 50300,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.KiaEv6Gt,
                    ModelId = VehicleModelIds.KiaEv6,
                    VariantName = "Kia EV6 GT (AWD)",
                    BasePrice = 63800,
                },
                // Chevrolet Blazer EV
                new VehicleVariant
                {
                    Id = VehicleVariantIds.ChevroletBlazerEvLt,
                    ModelId = VehicleModelIds.ChevroletBlazerEv,
                    VariantName = "Chevrolet Blazer EV LT (FWD)",
                    BasePrice = 44600,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.ChevroletBlazerEvRs,
                    ModelId = VehicleModelIds.ChevroletBlazerEv,
                    VariantName = "Chevrolet Blazer EV RS (RWD)",
                    BasePrice = 49900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.ChevroletBlazerEvSs,
                    ModelId = VehicleModelIds.ChevroletBlazerEv,
                    VariantName = "Chevrolet Blazer EV SS (AWD)",
                    BasePrice = 60600,
                },
                // Lucid Air
                new VehicleVariant
                {
                    Id = VehicleVariantIds.LucidAirPure,
                    ModelId = VehicleModelIds.LucidAir,
                    VariantName = "Lucid Air Pure (RWD)",
                    BasePrice = 69900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.LucidAirTouring,
                    ModelId = VehicleModelIds.LucidAir,
                    VariantName = "Lucid Air Touring (AWD)",
                    BasePrice = 78900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.LucidAirGrandTouring,
                    ModelId = VehicleModelIds.LucidAir,
                    VariantName = "Lucid Air Grand Touring (AWD)",
                    BasePrice = 110900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.LucidAirSapphire,
                    ModelId = VehicleModelIds.LucidAir,
                    VariantName = "Lucid Air Sapphire (AWD)",
                    BasePrice = 249000,
                },
                // Nissan Ariya
                new VehicleVariant
                {
                    Id = VehicleVariantIds.NissanAriyaEngage,
                    ModelId = VehicleModelIds.NissanAriya,
                    VariantName = "Nissan Ariya Engage (Standard Range FWD)",
                    BasePrice = 39770,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.NissanAriyaEvolvePlus,
                    ModelId = VehicleModelIds.NissanAriya,
                    VariantName = "Nissan Ariya Evolve+ (Extended Range FWD)",
                    BasePrice = 44370,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    ModelId = VehicleModelIds.NissanAriya,
                    VariantName = "Nissan Ariya Empower+",
                    BasePrice = 49260,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.NissanAriyaPremiere,
                    ModelId = VehicleModelIds.NissanAriya,
                    VariantName = "Nissan Ariya Premiere",
                    BasePrice = 52380,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    ModelId = VehicleModelIds.NissanAriya,
                    VariantName = "Nissan Ariya Platinum+ (Extended Range AWD)",
                    BasePrice = 54370,
                },
                // Porsche Taycan
                new VehicleVariant
                {
                    Id = VehicleVariantIds.PorscheTaycanBase,
                    ModelId = VehicleModelIds.PorscheTaycan,
                    VariantName = "Porsche Taycan Base (RWD Sedan)",
                    BasePrice = 99400,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.PorscheTaycan4s,
                    ModelId = VehicleModelIds.PorscheTaycan,
                    VariantName = "Porsche Taycan 4S (AWD Sedan)",
                    BasePrice = 118500,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.PorscheTaycanGts,
                    ModelId = VehicleModelIds.PorscheTaycan,
                    VariantName = "Porsche Taycan GTS (AWD Sedan)",
                    BasePrice = 147900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.PorscheTaycanTurbo,
                    ModelId = VehicleModelIds.PorscheTaycan,
                    VariantName = "Porsche Taycan Turbo (AWD Sedan)",
                    BasePrice = 173600,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.PorscheTaycanTurboS,
                    ModelId = VehicleModelIds.PorscheTaycan,
                    VariantName = "Porsche Taycan Turbo S (AWD Sedan)",
                    BasePrice = 209000,
                },
                // BMW i4
                new VehicleVariant
                {
                    Id = VehicleVariantIds.BmwI4Edrive35,
                    ModelId = VehicleModelIds.BmwI4,
                    VariantName = "BMW i4 eDrive35 (RWD)",
                    BasePrice = 52200,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.BmwI4Edrive40,
                    ModelId = VehicleModelIds.BmwI4,
                    VariantName = "BMW i4 eDrive40 (RWD)",
                    BasePrice = 57900,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.BmwI4Xdrive40,
                    ModelId = VehicleModelIds.BmwI4,
                    VariantName = "BMW i4 xDrive40 (AWD)",
                    BasePrice = 62300,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.BmwI4M50,
                    ModelId = VehicleModelIds.BmwI4,
                    VariantName = "BMW i4 M50 (AWD)",
                    BasePrice = 70700,
                },
                // Tesla Model Y
                new VehicleVariant
                {
                    Id = VehicleVariantIds.TeslaModelYLongRange,
                    ModelId = VehicleModelIds.TeslaModelY,
                    VariantName = "Tesla Model Y Long Range All-Wheel Drive",
                    BasePrice = 46630,
                },
                new VehicleVariant
                {
                    Id = VehicleVariantIds.TeslaModelYPerformance,
                    ModelId = VehicleModelIds.TeslaModelY,
                    VariantName = "Tesla Model Y Performance",
                    BasePrice = 57000,
                },
                // Tesla Model 3
                new VehicleVariant
                {
                    Id = VehicleVariantIds.TeslaModel3Performance,
                    ModelId = VehicleModelIds.TeslaModel3,
                    VariantName = "Tesla Model 3 Performance",
                    BasePrice = 54990,
                },
            ];
    }
}
