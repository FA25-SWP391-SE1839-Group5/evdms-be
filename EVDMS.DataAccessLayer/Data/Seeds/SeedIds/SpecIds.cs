namespace EVDMS.DataAccessLayer.Data.Seeds.SeedIds
{
    internal static class SpecIds
    {
        // Performance
        public static readonly Guid Horsepower = Guid.Parse("11111111-1111-1111-1111-111111111110");
        public static readonly Guid Torque = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid Acceleration = Guid.Parse(
            "11111111-1111-1111-1111-111111111112"
        );
        public static readonly Guid DriveType = Guid.Parse("11111111-1111-1111-1111-111111111113");
        public static readonly Guid MotorType = Guid.Parse("11111111-1111-1111-1111-111111111114");
        public static readonly Guid TopSpeed = Guid.Parse("11111111-1111-1111-1111-111111111115");
        public static readonly Guid CurbWeight = Guid.Parse("11111111-1111-1111-1111-111111111116");

        // Energy
        public static readonly Guid BatteryCapacity = Guid.Parse(
            "22222222-2222-2222-2222-222222222220"
        );
        public static readonly Guid Range = Guid.Parse("22222222-2222-2222-2222-222222222221");
        public static readonly Guid Efficiency = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public static readonly Guid BatteryChemistry = Guid.Parse(
            "22222222-2222-2222-2222-222222222223"
        );
        public static readonly Guid BatteryVoltage = Guid.Parse(
            "22222222-2222-2222-2222-222222222224"
        );
        public static readonly Guid RegenerativeBraking = Guid.Parse(
            "22222222-2222-2222-2222-222222222225"
        );

        // Charging
        public static readonly Guid MaxAcChargingRate = Guid.Parse(
            "33333333-3333-3333-3333-333333333330"
        );
        public static readonly Guid MaxDcChargingRate = Guid.Parse(
            "33333333-3333-3333-3333-333333333331"
        );
        public static readonly Guid DcFastChargingTime = Guid.Parse(
            "33333333-3333-3333-3333-333333333332"
        );
        public static readonly Guid AcChargingTime = Guid.Parse(
            "33333333-3333-3333-3333-333333333333"
        );
        public static readonly Guid ChargingPortType = Guid.Parse(
            "33333333-3333-3333-3333-333333333334"
        );

        // Practicality
        public static readonly Guid TowingCapacity = Guid.Parse(
            "44444444-4444-4444-4444-444444444440"
        );
        public static readonly Guid FrunkVolume = Guid.Parse(
            "44444444-4444-4444-4444-444444444441"
        );
        public static readonly Guid CargoVolume = Guid.Parse(
            "44444444-4444-4444-4444-444444444442"
        );
        public static readonly Guid HeatPump = Guid.Parse("44444444-4444-4444-4444-444444444443");
        public static readonly Guid V2L = Guid.Parse("44444444-4444-4444-4444-444444444444");
    }
}
