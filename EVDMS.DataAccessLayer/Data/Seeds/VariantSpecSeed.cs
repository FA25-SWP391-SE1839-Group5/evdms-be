using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class VariantSpecSeed
    {
        public static List<VariantSpec> VariantSpecs =>
            [
                // Hyundai Ioniq 5 SE (Standard Range RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000000"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.Horsepower,
                    Value = "168",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000001"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.Torque,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000002"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.Acceleration,
                    Value = "~8.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000003"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000004"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.MotorType,
                    Value = "Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000005"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.TopSpeed,
                    Value = "185",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000006"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1830",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000007"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "58",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000008"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.Range,
                    Value = "~354",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000009"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.Efficiency,
                    Value = "~164",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000a"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium-ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000b"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000c"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (paddle-controlled)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000d"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000e"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000000f"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000010"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000011"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000012"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~57",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000013"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~531 (max 1,587 seats down)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000014"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000015"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Se,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Hyundai Ioniq 5 SEL (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000016"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.Horsepower,
                    Value = "225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000017"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.Torque,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000018"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000019"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001a"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.MotorType,
                    Value = "Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001b"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.TopSpeed,
                    Value = "185",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001c"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1910",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001d"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "77.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001e"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.Range,
                    Value = "~488",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000001f"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.Efficiency,
                    Value = "~159",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000020"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium-ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000021"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000022"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000023"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000024"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000025"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000026"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000027"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000028"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~57",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000029"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.CargoVolume,
                    Value = "Same",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002a"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002b"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Sel,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Hyundai Ioniq 5 Limited (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002c"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.Horsepower,
                    Value = "225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002d"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.Torque,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002e"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000002f"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000030"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.MotorType,
                    Value = "Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000031"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.TopSpeed,
                    Value = "185",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000032"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1950",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000033"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "77.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000034"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.Range,
                    Value = "~488",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000035"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.Efficiency,
                    Value = "~159",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000036"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium-ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000037"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000038"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000039"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003a"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003b"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003c"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003d"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003e"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~57",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-00000000003f"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.CargoVolume,
                    Value = "Same",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000040"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-000000000041"),
                    VariantId = VehicleVariantIds.HyundaiIoniq5Limited,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Ford Mustang Mach-E Select (RWD, Std Range)
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000000"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.Horsepower,
                    Value = "~264",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000001"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.Torque,
                    Value = "~430",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000002"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.Acceleration,
                    Value = "~6.3–6.9",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000003"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000004"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.MotorType,
                    Value = "Single permanent magnet",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000005"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.TopSpeed,
                    Value = "180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000006"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2100",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000007"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~72",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000008"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.Range,
                    Value = "~402",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000009"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.Efficiency,
                    Value = "~172",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000a"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "LFP (Standard Range)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000b"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000c"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal drive)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000d"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000e"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "115–150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000000f"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~32–35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000010"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7–9",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000011"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000012"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000013"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~100",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000014"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.CargoVolume,
                    Value = "402 / 1420 max",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000015"),
                    VariantId = VehicleVariantIds.FordMachESelect,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Ford Mustang Mach-E Premium (RWD, Std Range)
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000016"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.Horsepower,
                    Value = "~265",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000017"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.Torque,
                    Value = "430",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000018"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.Acceleration,
                    Value = "~6.3–6.9",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000019"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001a"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.MotorType,
                    Value = "Single permanent magnet",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001b"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.TopSpeed,
                    Value = "180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001c"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2120",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001d"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~72",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001e"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.Range,
                    Value = "~402",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000001f"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.Efficiency,
                    Value = "~172",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000020"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "LFP (Standard Range)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000021"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000022"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000023"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000024"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "115–150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000025"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~32–35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000026"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7–9",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000027"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000028"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000029"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~100",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002a"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.CargoVolume,
                    Value = "402 / 1420 max",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002b"),
                    VariantId = VehicleVariantIds.FordMachEPremium,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Ford Mustang Mach-E California Route 1 (ER AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002c"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.Horsepower,
                    Value = "346",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002d"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.Torque,
                    Value = "580",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002e"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.Acceleration,
                    Value = "~5.1",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000002f"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000030"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual permanent magnet",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000031"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.TopSpeed,
                    Value = "180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000032"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2145",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000033"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~91",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000034"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.Range,
                    Value = "~505",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000035"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.Efficiency,
                    Value = "~200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000036"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "NMC (Extended Range)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000037"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000038"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000039"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003a"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003b"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~38",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003c"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~10–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003d"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003e"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000003f"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~100",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000040"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.CargoVolume,
                    Value = "841 / 1823 max",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000041"),
                    VariantId = VehicleVariantIds.FordMachECaliforniaRt1,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Ford Mustang Mach-E GT (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000042"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.Horsepower,
                    Value = "480",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000043"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.Torque,
                    Value = "813",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000044"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.Acceleration,
                    Value = "4.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000045"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000046"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual permanent magnet",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000047"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.TopSpeed,
                    Value = "200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000048"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2273",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000049"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~88",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004a"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.Range,
                    Value = "~450",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004b"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.Efficiency,
                    Value = "~230",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004c"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "NMC (Extended Range)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004d"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004e"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-00000000004f"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000050"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000051"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~38",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000052"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~10",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000053"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000054"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~750",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000055"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~100",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000056"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.CargoVolume,
                    Value = "402 / 1420 max",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-000000000057"),
                    VariantId = VehicleVariantIds.FordMachEGt,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Kia EV6 Light (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000000"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.Horsepower,
                    Value = "167",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000001"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.Torque,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000002"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.Acceleration,
                    Value = "~8.3",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000003"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000004"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.MotorType,
                    Value = "Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000005"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.TopSpeed,
                    Value = "185",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000006"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1875–1880",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000007"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "58–63",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000008"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.Range,
                    Value = "~381",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000009"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.Efficiency,
                    Value = "~165",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000a"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000b"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~523",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000c"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (i‑Pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000d"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000e"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000000f"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~20",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000010"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000011"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000012"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~52",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000013"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.CargoVolume,
                    Value = "520 / 1300+ seats down",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000014"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000015"),
                    VariantId = VehicleVariantIds.KiaEv6Light,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Kia EV6 Wind (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000016"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.Horsepower,
                    Value = "225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000017"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.Torque,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000018"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000019"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001a"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.MotorType,
                    Value = "Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001b"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.TopSpeed,
                    Value = "185",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001c"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2050",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001d"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "77.4–84",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001e"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.Range,
                    Value = "~499",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000001f"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.Efficiency,
                    Value = "~155",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000020"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000021"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~697",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000022"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000023"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000024"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "240–350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000025"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000026"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7–8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000027"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000028"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000029"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~52",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002a"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.CargoVolume,
                    Value = "520 / 1300+",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002b"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002c"),
                    VariantId = VehicleVariantIds.KiaEv6Wind,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Kia EV6 GT (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002d"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.Horsepower,
                    Value = "576",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002e"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.Torque,
                    Value = "740",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000002f"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.5–3.6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000030"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000031"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual Permanent Magnet Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000032"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.TopSpeed,
                    Value = "260",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000033"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2220",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000034"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "77.4–84",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000035"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.Range,
                    Value = "~395–450",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000036"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.Efficiency,
                    Value = "~203",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000037"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Lithium‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000038"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~697",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000039"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003a"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003b"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "240–350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003c"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003d"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7–8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003e"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-00000000003f"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000040"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~20–52",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000041"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.CargoVolume,
                    Value = "480–490 / 1260",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000042"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000043"),
                    VariantId = VehicleVariantIds.KiaEv6Gt,
                    SpecId = SpecIds.V2L,
                    Value = "3.6",
                },
                // Chevrolet Blazer EV LT (FWD)
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000000"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.Horsepower,
                    Value = "220",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000001"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.Torque,
                    Value = "~330",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000002"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.0–7.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000003"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.DriveType,
                    Value = "FWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000004"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000005"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.TopSpeed,
                    Value = "~180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000006"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2270",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000007"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~85",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000008"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.Range,
                    Value = "~502",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000009"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.Efficiency,
                    Value = "~169",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000a"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Ultium Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000b"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000c"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "One‑Pedal Driving",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000d"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000e"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000000f"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000010"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~9.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000011"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000012"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~680",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000013"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.CargoVolume,
                    Value = "722–1674",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000014"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvLt,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Chevrolet Blazer EV RS (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000015"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.Horsepower,
                    Value = "345–365",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000016"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.Torque,
                    Value = "441",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000017"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.Acceleration,
                    Value = "~5.7–6.0",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000018"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000019"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (rear)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001a"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.TopSpeed,
                    Value = "~210",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001b"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2470–2540",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001c"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~91–102",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001d"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.Range,
                    Value = "~449–521",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001e"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.Efficiency,
                    Value = "~200–228",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000001f"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Ultium Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000020"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000021"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "One‑Pedal Driving",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000022"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000023"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "150",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000024"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000025"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000026"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000027"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1588",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000028"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.CargoVolume,
                    Value = "722–1674",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000029"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002a"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvRs,
                    SpecId = SpecIds.V2L,
                    Value = "V2H supported",
                },
                // Chevrolet Blazer EV SS (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002b"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.Horsepower,
                    Value = "615",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002c"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.Torque,
                    Value = "880",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002d"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.Acceleration,
                    Value = "~3.4–4.0",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002e"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000002f"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM (front + rear)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000030"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.TopSpeed,
                    Value = "~210+",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000031"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000032"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "102",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000033"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.Range,
                    Value = "~486",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000034"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.Efficiency,
                    Value = "~210–220",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000035"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Ultium Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000036"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000037"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "One‑Pedal Driving + Regen on Demand",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000038"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-000000000039"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "190–200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000003a"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~30–32",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000003b"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~11.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000003c"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000003d"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.CargoVolume,
                    Value = "722–1674",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-00000000003e"),
                    VariantId = VehicleVariantIds.ChevroletBlazerEvSs,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Lucid Air Pure (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000000"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.Horsepower,
                    Value = "430",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000001"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.Torque,
                    Value = "~550",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000002"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.Acceleration,
                    Value = "4.7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000003"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000004"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (rear)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000005"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.TopSpeed,
                    Value = "200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000006"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2070",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000007"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "84",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000008"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.Range,
                    Value = "~676",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000009"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.Efficiency,
                    Value = "~158",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000a"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000b"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800+",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000c"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000d"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "22",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000e"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "210",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000000f"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~27",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000010"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~10",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000011"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000012"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~283",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000013"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~910 total (frunk + trunk)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000014"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000015"),
                    VariantId = VehicleVariantIds.LucidAirPure,
                    SpecId = SpecIds.V2L,
                    Value = "Supported",
                },
                // Lucid Air Touring (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000016"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.Horsepower,
                    Value = "620",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000017"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.Torque,
                    Value = "~1200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000018"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000019"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001a"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001b"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.TopSpeed,
                    Value = "225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001c"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2270",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001d"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~89–92",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001e"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.Range,
                    Value = "~653",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000001f"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.Efficiency,
                    Value = "~162",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000020"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000021"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "700+",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000022"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000023"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "19.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000024"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000025"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~32",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000026"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~10",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000027"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000028"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~280",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000029"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~910",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002a"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002b"),
                    VariantId = VehicleVariantIds.LucidAirTouring,
                    SpecId = SpecIds.V2L,
                    Value = "Supported",
                },
                // Lucid Air Grand Touring (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002c"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.Horsepower,
                    Value = "819",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002d"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.Torque,
                    Value = "1200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002e"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000002f"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000030"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000031"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.TopSpeed,
                    Value = "270",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000032"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2360–2435",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000033"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "112",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000034"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.Range,
                    Value = "~824",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000035"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.Efficiency,
                    Value = "~160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000036"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000037"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "900+",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000038"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000039"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "19.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003a"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003b"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~33",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003c"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~13",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003d"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003e"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~280",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000003f"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~910",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000040"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000041"),
                    VariantId = VehicleVariantIds.LucidAirGrandTouring,
                    SpecId = SpecIds.V2L,
                    Value = "Supported",
                },
                // Lucid Air Sapphire (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000042"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.Horsepower,
                    Value = "1234",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000043"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.Torque,
                    Value = "1390",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000044"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.Acceleration,
                    Value = "~2.0",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000045"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD (triple motor)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000046"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.MotorType,
                    Value = "Triple PMSM (2 rear + 1 front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000047"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.TopSpeed,
                    Value = "330",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000048"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2420–2435",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000049"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "118",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004a"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.Range,
                    Value = "~687",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004b"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.Efficiency,
                    Value = "~190",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004c"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004d"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "900",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004e"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (track‑tuned)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-00000000004f"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "19.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000050"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000051"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~33",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000052"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~13",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000053"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000054"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~280",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000055"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~910",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000056"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-000000000057"),
                    VariantId = VehicleVariantIds.LucidAirSapphire,
                    SpecId = SpecIds.V2L,
                    Value = "Supported",
                },
                // Nissan Ariya Engage (Std Range FWD)
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000000"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.Horsepower,
                    Value = "214",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000001"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.Torque,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000002"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000003"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.DriveType,
                    Value = "FWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000004"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000005"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.TopSpeed,
                    Value = "160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000006"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1960",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000007"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "63–66",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000008"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.Range,
                    Value = "~348",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000009"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.Efficiency,
                    Value = "~207",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000a"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000b"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000c"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000d"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "7.2–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000e"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "130",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000000f"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000010"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~10",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000011"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000012"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.CargoVolume,
                    Value = "646–1691",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000013"),
                    VariantId = VehicleVariantIds.NissanAriyaEngage,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Nissan Ariya Evolve+ (Ext Range FWD)
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000014"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.Horsepower,
                    Value = "238",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000015"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.Torque,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000016"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000017"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.DriveType,
                    Value = "FWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000018"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000019"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.TopSpeed,
                    Value = "160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001a"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2090",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001b"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "87–91",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001c"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.Range,
                    Value = "~465",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001d"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.Efficiency,
                    Value = "~193",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001e"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000001f"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000020"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000021"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "7.2–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000022"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "130",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000023"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000024"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~14",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000025"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000026"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.CargoVolume,
                    Value = "646–1691",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000027"),
                    VariantId = VehicleVariantIds.NissanAriyaEvolvePlus,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Nissan Ariya Empower+ (FWD)
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000028"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.Horsepower,
                    Value = "238",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000029"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.Torque,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002a"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002b"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.DriveType,
                    Value = "FWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002c"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002d"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.TopSpeed,
                    Value = "160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002e"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2090",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000002f"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "87–91",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000030"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.Range,
                    Value = "~465",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000031"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.Efficiency,
                    Value = "~193",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000032"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000033"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000034"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000035"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "7.2–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000036"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "130",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000037"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000038"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~14",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000039"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003a"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.CargoVolume,
                    Value = "646–1691",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003b"),
                    VariantId = VehicleVariantIds.NissanAriyaEmpowerPlus,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Nissan Ariya Premiere (FWD)
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003c"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.Horsepower,
                    Value = "238",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003d"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.Torque,
                    Value = "300",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003e"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.Acceleration,
                    Value = "~7.6",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000003f"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.DriveType,
                    Value = "FWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000040"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM (front)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000041"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.TopSpeed,
                    Value = "160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000042"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2090",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000043"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "87–91",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000044"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.Range,
                    Value = "~465",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000045"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.Efficiency,
                    Value = "~193",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000046"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000047"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000048"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000049"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "7.2–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004a"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "130",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004b"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004c"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~14",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004d"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004e"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.CargoVolume,
                    Value = "646–1691",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000004f"),
                    VariantId = VehicleVariantIds.NissanAriyaPremiere,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // Nissan Ariya Platinum+ (Ext Range AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000050"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.Horsepower,
                    Value = "389",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000051"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.Torque,
                    Value = "600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000052"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.Acceleration,
                    Value = "~5.1",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000053"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD (e‑4ORCE)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000054"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM (front + rear)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000055"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.TopSpeed,
                    Value = "160",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000056"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2294–2490",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000057"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "87–91",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000058"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.Range,
                    Value = "~438",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000059"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.Efficiency,
                    Value = "~228",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005a"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005b"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "350",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005c"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005d"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "7.2–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005e"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "130",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-00000000005f"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~35",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000060"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~13",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000061"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000062"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~680–1000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000063"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.CargoVolume,
                    Value = "646–1691",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-000000000064"),
                    VariantId = VehicleVariantIds.NissanAriyaPlatinumPlus,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Porsche Taycan Base (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777700"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.Horsepower,
                    Value = "402–429",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777701"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.Torque,
                    Value = "345–420",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777702"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.Acceleration,
                    Value = "5.4",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777703"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777704"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.MotorType,
                    Value = "Single PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777705"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.TopSpeed,
                    Value = "230",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777706"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,100–2,125",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777707"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "71–82",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777708"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.Range,
                    Value = "431–503",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777709"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.Efficiency,
                    Value = "~200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770a"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770b"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770c"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770d"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11 (22 opt.)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770e"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "225–270",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777770f"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18–22",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777710"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~9–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777711"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777712"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~84",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777713"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~407–491",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777714"),
                    VariantId = VehicleVariantIds.PorscheTaycanBase,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Porsche Taycan 4S (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777715"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.Horsepower,
                    Value = "523–590",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777716"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.Torque,
                    Value = "650–710",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777717"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.7–4.0",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777718"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777719"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771a"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.TopSpeed,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771b"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,190–2,200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771c"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "82–97",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771d"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.Range,
                    Value = "407–506",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771e"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.Efficiency,
                    Value = "~210",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777771f"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777720"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777721"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777722"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11 (22 opt.)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777723"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "225–270",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777724"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18–22",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777725"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~9–11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777726"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777727"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~84",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777728"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~488",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777729"),
                    VariantId = VehicleVariantIds.PorscheTaycan4s,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Porsche Taycan GTS (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772a"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.Horsepower,
                    Value = "590–690",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772b"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.Torque,
                    Value = "850",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772c"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.3–3.7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772d"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772e"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777772f"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.TopSpeed,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777730"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,345",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777731"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "84–97",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777732"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.Range,
                    Value = "504–505",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777733"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.Efficiency,
                    Value = "~186–203",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777734"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777735"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777736"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777737"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11 (22 opt.)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777738"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "270–320",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777739"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773a"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773b"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773c"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~81",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773d"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~488",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773e"),
                    VariantId = VehicleVariantIds.PorscheTaycanGts,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Porsche Taycan Turbo (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777773f"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.Horsepower,
                    Value = "671–871",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777740"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.Torque,
                    Value = "850–890",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777741"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.Acceleration,
                    Value = "2.7–3.2",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777742"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777743"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777744"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.TopSpeed,
                    Value = "260",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777745"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,355",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777746"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "84–97",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777747"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.Range,
                    Value = "450–505",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777748"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.Efficiency,
                    Value = "~220–230",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777749"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774a"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774b"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774c"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11 (22 opt.)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774d"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "270–320",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774e"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777774f"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777750"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777751"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~81",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777752"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~447",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777753"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurbo,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Porsche Taycan Turbo S (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777754"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.Horsepower,
                    Value = "751–938",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777755"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.Torque,
                    Value = "1,050–1,110",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777756"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.Acceleration,
                    Value = "2.4–2.8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777757"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777758"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777759"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.TopSpeed,
                    Value = "260",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775a"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,295–2,345",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775b"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "84–97",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775c"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.Range,
                    Value = "412–506",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775d"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.Efficiency,
                    Value = "~230–250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775e"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-77777777775f"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "800",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777760"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777761"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11 (22 opt.)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777762"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "270–320",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777763"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~18",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777764"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777765"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777766"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~81",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777767"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.CargoVolume,
                    Value = "~447",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777768"),
                    VariantId = VehicleVariantIds.PorscheTaycanTurboS,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // BMW i4 eDrive35 (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888800"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.Horsepower,
                    Value = "282",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888801"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.Torque,
                    Value = "400",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888802"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.Acceleration,
                    Value = "5.8–6.0",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888803"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888804"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.MotorType,
                    Value = "Single Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888805"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.TopSpeed,
                    Value = "190",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888806"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,000–2,075",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888807"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "67.1",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888808"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.Range,
                    Value = "406–485",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888809"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.Efficiency,
                    Value = "~156",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880a"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880b"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~353",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880c"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880d"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880e"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "180",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888880f"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~32",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888810"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888811"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888812"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888813"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.CargoVolume,
                    Value = "470 / 1,290 seats down",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888814"),
                    VariantId = VehicleVariantIds.BmwI4Edrive35,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // BMW i4 eDrive40 (RWD)
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888815"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.Horsepower,
                    Value = "335–340",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888816"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.Torque,
                    Value = "430",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888817"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.Acceleration,
                    Value = "5.6–5.7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888818"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.DriveType,
                    Value = "RWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888819"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.MotorType,
                    Value = "Single Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881a"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.TopSpeed,
                    Value = "190",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881b"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,050–2,125",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881c"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "81.3",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881d"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.Range,
                    Value = "493–590",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881e"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.Efficiency,
                    Value = "~159",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888881f"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888820"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~399",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888821"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888822"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888823"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "205",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888824"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~30",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888825"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888826"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888827"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888828"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.CargoVolume,
                    Value = "470 / 1,290",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888829"),
                    VariantId = VehicleVariantIds.BmwI4Edrive40,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // BMW i4 xDrive40 (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882a"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.Horsepower,
                    Value = "396–401",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882b"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.Torque,
                    Value = "600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882c"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.Acceleration,
                    Value = "4.8–5.1",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882d"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882e"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888882f"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.TopSpeed,
                    Value = "200",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888830"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,185–2,260",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888831"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "81.3",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888832"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.Range,
                    Value = "459–546",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888833"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.Efficiency,
                    Value = "~166",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888834"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888835"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~399",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888836"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888837"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888838"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "205",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888839"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~30",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883a"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883b"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883c"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883d"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.CargoVolume,
                    Value = "470 / 1,290",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883e"),
                    VariantId = VehicleVariantIds.BmwI4Xdrive40,
                    SpecId = SpecIds.HeatPump,
                    Value = "Optional",
                },
                // BMW i4 M50 (AWD)
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888883f"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.Horsepower,
                    Value = "536–544",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888840"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.Torque,
                    Value = "795",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888841"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.7–3.9",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888842"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888843"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual Synchronous",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888844"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.TopSpeed,
                    Value = "225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888845"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~2,215–2,290",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888846"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "81.3",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888847"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.Range,
                    Value = "416–521",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888848"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.Efficiency,
                    Value = "~180–225",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888849"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NMC)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884a"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~399",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884b"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Adjustable",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884c"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884d"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "205",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884e"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~30",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-88888888884f"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888850"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "CCS Combo",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888851"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888852"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.CargoVolume,
                    Value = "470 / 1,290",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888853"),
                    VariantId = VehicleVariantIds.BmwI4M50,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Tesla Model Y Long Range AWD
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999900"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.Horsepower,
                    Value = "~514",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999901"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.Torque,
                    Value = "~493",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999902"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.Acceleration,
                    Value = "4.8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999903"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD (dual motor)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999904"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999905"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.TopSpeed,
                    Value = "201",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999906"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1,994–2,072",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999907"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~75–78",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999908"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.Range,
                    Value = "~533",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999909"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.Efficiency,
                    Value = "~165",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990a"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NCM)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990b"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~345–360",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990c"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Standard (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990d"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990e"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999990f"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~27–30",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999910"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999911"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "Tesla NACS (NA) / CCS (EU)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999912"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999913"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~117",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999914"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.CargoVolume,
                    Value = "854–2,158",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999915"),
                    VariantId = VehicleVariantIds.TeslaModelYLongRange,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Tesla Model Y Performance
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999916"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.Horsepower,
                    Value = "~534",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999917"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.Torque,
                    Value = "~741",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999918"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.Acceleration,
                    Value = "3.5–3.7",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999919"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD (dual motor)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991a"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991b"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.TopSpeed,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991c"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1,995–2,108",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991d"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~77–79",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991e"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.Range,
                    Value = "~460–514",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999991f"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.Efficiency,
                    Value = "~172",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999920"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NCM)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999921"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~360",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999922"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Standard (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999923"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999924"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999925"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~29–30",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999926"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8.5",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999927"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "Tesla NACS / CCS",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999928"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1,600",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999929"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~117",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992a"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.CargoVolume,
                    Value = "854–2,158",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992b"),
                    VariantId = VehicleVariantIds.TeslaModelYPerformance,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
                // Tesla Model 3 Performance
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992c"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.Horsepower,
                    Value = "~510–530",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992d"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.Torque,
                    Value = "~660",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992e"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.Acceleration,
                    Value = "2.9–3.3",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999992f"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.DriveType,
                    Value = "AWD (dual motor)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999930"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.MotorType,
                    Value = "Dual PMSM",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999931"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.TopSpeed,
                    Value = "260–261",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999932"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.CurbWeight,
                    Value = "~1,851–1,906",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999933"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.BatteryCapacity,
                    Value = "~82",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999934"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.Range,
                    Value = "~567",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999935"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.Efficiency,
                    Value = "~139–172",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999936"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.BatteryChemistry,
                    Value = "Li‑ion (NCM)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999937"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.BatteryVoltage,
                    Value = "~360",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999938"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.RegenerativeBraking,
                    Value = "Standard (1‑pedal)",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999939"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.MaxAcChargingRate,
                    Value = "11",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993a"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.MaxDcChargingRate,
                    Value = "250",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993b"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.DcFastChargingTime,
                    Value = "~25–27",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993c"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.AcChargingTime,
                    Value = "~8",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993d"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.ChargingPortType,
                    Value = "Tesla NACS / CCS",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993e"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.TowingCapacity,
                    Value = "~1,000",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-99999999993f"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.FrunkVolume,
                    Value = "~88",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999940"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.CargoVolume,
                    Value = "542",
                },
                new VariantSpec
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999941"),
                    VariantId = VehicleVariantIds.TeslaModel3Performance,
                    SpecId = SpecIds.HeatPump,
                    Value = "Standard",
                },
            ];
    }
}
