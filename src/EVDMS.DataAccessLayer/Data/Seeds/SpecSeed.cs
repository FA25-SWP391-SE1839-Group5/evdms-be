using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class SpecSeed
    {
        public static List<Spec> Specs =>
            [
                // Performance
                new Spec
                {
                    Id = SpecIds.Horsepower,
                    SpecName = "Horsepower",
                    Unit = "hp",
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.Torque,
                    SpecName = "Torque",
                    Unit = "Nm",
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.Acceleration,
                    SpecName = "0-100 km/h Acceleration",
                    Unit = "s",
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.DriveType,
                    SpecName = "Drive Type",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.MotorType,
                    SpecName = "Motor Type",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.TopSpeed,
                    SpecName = "Top Speed",
                    Unit = "km/h",
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                new Spec
                {
                    Id = SpecIds.CurbWeight,
                    SpecName = "Curb Weight",
                    Unit = "kg",
                    SpecCategoryId = SpecCategoryIds.Performance,
                },
                // Energy
                new Spec
                {
                    Id = SpecIds.BatteryCapacity,
                    SpecName = "Battery Capacity",
                    Unit = "kWh",
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                new Spec
                {
                    Id = SpecIds.Range,
                    SpecName = "Range",
                    Unit = "km",
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                new Spec
                {
                    Id = SpecIds.Efficiency,
                    SpecName = "Efficiency",
                    Unit = "Wh/km",
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                new Spec
                {
                    Id = SpecIds.BatteryChemistry,
                    SpecName = "Battery Chemistry",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                new Spec
                {
                    Id = SpecIds.BatteryVoltage,
                    SpecName = "Battery Voltage Architecture",
                    Unit = "V",
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                new Spec
                {
                    Id = SpecIds.RegenerativeBraking,
                    SpecName = "Regenerative Braking Capacity",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Energy,
                },
                // III. Charging
                new Spec
                {
                    Id = SpecIds.MaxAcChargingRate,
                    SpecName = "Max AC Charging Rate",
                    Unit = "kW",
                    SpecCategoryId = SpecCategoryIds.Charging,
                },
                new Spec
                {
                    Id = SpecIds.MaxDcChargingRate,
                    SpecName = "Max DC Fast Charging Rate",
                    Unit = "kW",
                    SpecCategoryId = SpecCategoryIds.Charging,
                },
                new Spec
                {
                    Id = SpecIds.DcFastChargingTime,
                    SpecName = "DC Fast Charging Time (10-80%)",
                    Unit = "min",
                    SpecCategoryId = SpecCategoryIds.Charging,
                },
                new Spec
                {
                    Id = SpecIds.AcChargingTime,
                    SpecName = "AC Charging Time (0-100%)",
                    Unit = "h",
                    SpecCategoryId = SpecCategoryIds.Charging,
                },
                new Spec
                {
                    Id = SpecIds.ChargingPortType,
                    SpecName = "Charging Port Type(s)",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Charging,
                },
                // Practicality
                new Spec
                {
                    Id = SpecIds.TowingCapacity,
                    SpecName = "Towing Capacity",
                    Unit = "kg",
                    SpecCategoryId = SpecCategoryIds.Practicality,
                },
                new Spec
                {
                    Id = SpecIds.FrunkVolume,
                    SpecName = "Frunk Volume",
                    Unit = "L",
                    SpecCategoryId = SpecCategoryIds.Practicality,
                },
                new Spec
                {
                    Id = SpecIds.CargoVolume,
                    SpecName = "Cargo Volume",
                    Unit = "L",
                    SpecCategoryId = SpecCategoryIds.Practicality,
                },
                new Spec
                {
                    Id = SpecIds.HeatPump,
                    SpecName = "Heat Pump",
                    Unit = null,
                    SpecCategoryId = SpecCategoryIds.Practicality,
                },
                new Spec
                {
                    Id = SpecIds.V2L,
                    SpecName = "V2L (Vehicle-to-Load) Capability",
                    Unit = "kW",
                    SpecCategoryId = SpecCategoryIds.Practicality,
                },
            ];
    }
}
