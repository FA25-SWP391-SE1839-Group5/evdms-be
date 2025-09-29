using EVDMS.Common.Enums;
using EVDMS.Common.Helpers;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VehicleVariantSeed
    {
        public static List<VehicleVariant> VehicleVariants =>
            [
                // Tesla Model Y
                new VehicleVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    ModelId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Tesla Model Y Long Range All-Wheel Drive",
                    BasePrice = 46630,
                    SpecsObject = new VehicleSpecs
                    {
                        Horsepower = new SpecDetail { Value = 514, Unit = "hp" },
                        Torque = new SpecDetail { Value = 493, Unit = "Nm" },
                        Acceleration = new SpecDetail { Value = 4.8, Unit = "s" },
                        DriveType = new SpecDetail { Value = "AWD" },
                        MotorType = new SpecDetail { Value = "Dual PMSM" },
                        TopSpeed = new SpecDetail { Value = 201, Unit = "km/h" },
                        CurbWeight = new SpecDetail { Value = 1994, Unit = "kg" },
                        BatteryCapacity = new SpecDetail { Value = 75, Unit = "kWh" },
                        Range = new SpecDetail { Value = 533, Unit = "km" },
                        Efficiency = new SpecDetail { Value = 165, Unit = "Wh/km" },
                        BatteryChemistry = new SpecDetail { Value = "Li‑ion (NCM)" },
                        BatteryVoltageArchitecture = new SpecDetail { Value = 345, Unit = "V" },
                        RegenerativeBrakingCapacity = new SpecDetail
                        {
                            Value = "Standard (1‑pedal)",
                        },
                        MaxAcChargingRate = new SpecDetail { Value = 11, Unit = "kW" },
                        MaxDcFastChargingRate = new SpecDetail { Value = 250, Unit = "kW" },
                        DcFastChargingTime = new SpecDetail { Value = 27, Unit = "min" },
                        AcChargingTime = new SpecDetail { Value = 8, Unit = "h" },
                        ChargingPortTypes = new SpecDetail { Value = "Tesla NACS (NA) / CCS (EU)" },
                        TowingCapacity = new SpecDetail { Value = 1600, Unit = "kg" },
                        FrunkVolume = new SpecDetail { Value = 117, Unit = "L" },
                        CargoVolume = new SpecDetail { Value = 854, Unit = "L" },
                        HeatPump = new SpecDetail { Value = "Standard" },
                        V2lCapability = new SpecDetail { Value = 3.6, Unit = "kW" },
                    },

                    FeaturesObject = new VehicleFeatures
                    {
                        Safety =
                        [
                            FeatureType.AutomaticEmergencyBraking,
                            FeatureType.BlindSpotMonitor,
                            FeatureType.LaneDepartureWarning,
                            FeatureType.BackupCamera,
                        ],
                        Convenience =
                        [
                            FeatureType.KeylessEntry,
                            FeatureType.PowerLiftgate,
                            FeatureType.AdaptiveCruiseControl,
                        ],
                        Entertainment =
                        [
                            FeatureType.AppleCarPlay,
                            FeatureType.AndroidAuto,
                            FeatureType.PremiumSoundSystem,
                            FeatureType.WifiHotspot,
                        ],
                        Exterior =
                        [
                            FeatureType.AlloyWheels,
                            FeatureType.LedHeadlights,
                            FeatureType.RoofRails,
                            FeatureType.Sunroof,
                        ],
                        Seating =
                        [
                            FeatureType.HeatedSeats,
                            FeatureType.VentilatedSeats,
                            FeatureType.ThirdRowSeating,
                        ],
                    },
                },
                new VehicleVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    ModelId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Tesla Model Y Performance",
                    BasePrice = 57000,
                    SpecsObject = new VehicleSpecs
                    {
                        Horsepower = new SpecDetail { Value = 534, Unit = "hp" },
                        Torque = new SpecDetail { Value = 660, Unit = "Nm" },
                        Acceleration = new SpecDetail { Value = 3.7, Unit = "s" },
                        DriveType = new SpecDetail { Value = "AWD" },
                        MotorType = new SpecDetail { Value = "Dual PMSM Performance" },
                        TopSpeed = new SpecDetail { Value = 250, Unit = "km/h" },
                        CurbWeight = new SpecDetail { Value = 2003, Unit = "kg" },
                        BatteryCapacity = new SpecDetail { Value = 78, Unit = "kWh" },
                        Range = new SpecDetail { Value = 488, Unit = "km" },
                        Efficiency = new SpecDetail { Value = 175, Unit = "Wh/km" },
                        BatteryChemistry = new SpecDetail { Value = "Li‑ion (NCA)" },
                        BatteryVoltageArchitecture = new SpecDetail { Value = 355, Unit = "V" },
                        RegenerativeBrakingCapacity = new SpecDetail
                        {
                            Value = "Enhanced (1‑pedal)",
                        },
                        MaxAcChargingRate = new SpecDetail { Value = 11, Unit = "kW" },
                        MaxDcFastChargingRate = new SpecDetail { Value = 250, Unit = "kW" },
                        DcFastChargingTime = new SpecDetail { Value = 25, Unit = "min" },
                        AcChargingTime = new SpecDetail { Value = 7.5, Unit = "h" },
                        ChargingPortTypes = new SpecDetail { Value = "Tesla NACS (NA) / CCS (EU)" },
                        TowingCapacity = new SpecDetail { Value = 1500, Unit = "kg" },
                        FrunkVolume = new SpecDetail { Value = 110, Unit = "L" },
                        CargoVolume = new SpecDetail { Value = 860, Unit = "L" },
                        HeatPump = new SpecDetail { Value = "Standard" },
                        V2lCapability = new SpecDetail { Value = 3.6, Unit = "kW" },
                    },
                    FeaturesObject = new VehicleFeatures
                    {
                        Safety =
                        [
                            FeatureType.AutomaticEmergencyBraking,
                            FeatureType.BlindSpotMonitor,
                            FeatureType.LaneDepartureWarning,
                            FeatureType.BackupCamera,
                        ],
                        Convenience =
                        [
                            FeatureType.KeylessEntry,
                            FeatureType.PowerLiftgate,
                            FeatureType.AdaptiveCruiseControl,
                        ],
                        Entertainment =
                        [
                            FeatureType.AppleCarPlay,
                            FeatureType.AndroidAuto,
                            FeatureType.PremiumSoundSystem,
                            FeatureType.WifiHotspot,
                        ],
                        Exterior =
                        [
                            FeatureType.AlloyWheels,
                            FeatureType.LedHeadlights,
                            FeatureType.RoofRails,
                            FeatureType.Sunroof,
                        ],
                        Seating = [FeatureType.HeatedSeats, FeatureType.ThirdRowSeating],
                    },
                },
                // Tesla Model 3
                new VehicleVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    ModelId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Tesla Model 3 Performance",
                    BasePrice = 54990,
                    SpecsObject = new VehicleSpecs
                    {
                        Horsepower = new SpecDetail { Value = 510, Unit = "hp" },
                        Torque = new SpecDetail { Value = 660, Unit = "Nm" },
                        Acceleration = new SpecDetail { Value = 3.1, Unit = "s" },
                        DriveType = new SpecDetail { Value = "AWD" },
                        MotorType = new SpecDetail { Value = "Dual PMSM" },
                        TopSpeed = new SpecDetail { Value = 261, Unit = "km/h" },
                        CurbWeight = new SpecDetail { Value = 1844, Unit = "kg" },
                        BatteryCapacity = new SpecDetail { Value = 82, Unit = "kWh" },
                        Range = new SpecDetail { Value = 547, Unit = "km" },
                        Efficiency = new SpecDetail { Value = 153, Unit = "Wh/km" },
                        BatteryChemistry = new SpecDetail { Value = "Li‑ion (NCA)" },
                        BatteryVoltageArchitecture = new SpecDetail { Value = 355, Unit = "V" },
                        RegenerativeBrakingCapacity = new SpecDetail
                        {
                            Value = "Standard (1‑pedal)",
                        },
                        MaxAcChargingRate = new SpecDetail { Value = 11, Unit = "kW" },
                        MaxDcFastChargingRate = new SpecDetail { Value = 250, Unit = "kW" },
                        DcFastChargingTime = new SpecDetail { Value = 30, Unit = "min" },
                        AcChargingTime = new SpecDetail { Value = 8, Unit = "h" },
                        ChargingPortTypes = new SpecDetail { Value = "Tesla NACS (NA) / CCS (EU)" },
                        TowingCapacity = new SpecDetail { Value = 1000, Unit = "kg" },
                        FrunkVolume = new SpecDetail { Value = 88, Unit = "L" },
                        CargoVolume = new SpecDetail { Value = 542, Unit = "L" },
                    },
                    FeaturesObject = new VehicleFeatures
                    {
                        Safety =
                        [
                            FeatureType.AutomaticEmergencyBraking,
                            FeatureType.LaneDepartureWarning,
                            FeatureType.BackupCamera,
                        ],
                        Convenience = [FeatureType.KeylessEntry, FeatureType.PowerLiftgate],
                        Entertainment = [FeatureType.PremiumSoundSystem],
                        Exterior = [FeatureType.LedHeadlights, FeatureType.AlloyWheels],
                        Seating = [FeatureType.HeatedSeats],
                    },
                },
            ];
    }
}
