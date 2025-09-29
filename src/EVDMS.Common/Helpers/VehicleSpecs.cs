namespace EVDMS.Common.Helpers
{
    public class VehicleSpecs
    {
        // Performance
        public SpecDetail Horsepower { get; set; } = new();
        public SpecDetail Torque { get; set; } = new();
        public SpecDetail Acceleration { get; set; } = new(); // 0-100 km/h
        public SpecDetail DriveType { get; set; } = new();
        public SpecDetail MotorType { get; set; } = new();
        public SpecDetail TopSpeed { get; set; } = new();
        public SpecDetail CurbWeight { get; set; } = new();

        // Energy
        public SpecDetail BatteryCapacity { get; set; } = new();
        public SpecDetail Range { get; set; } = new();
        public SpecDetail Efficiency { get; set; } = new();
        public SpecDetail BatteryChemistry { get; set; } = new();
        public SpecDetail BatteryVoltageArchitecture { get; set; } = new();
        public SpecDetail RegenerativeBrakingCapacity { get; set; } = new();

        // Charging
        public SpecDetail MaxAcChargingRate { get; set; } = new();
        public SpecDetail MaxDcFastChargingRate { get; set; } = new();
        public SpecDetail DcFastChargingTime { get; set; } = new(); // 10–80%
        public SpecDetail AcChargingTime { get; set; } = new(); // 0–100%
        public SpecDetail ChargingPortTypes { get; set; } = new();

        // Practicality
        public SpecDetail TowingCapacity { get; set; } = new();
        public SpecDetail FrunkVolume { get; set; } = new();
        public SpecDetail CargoVolume { get; set; } = new();
        public SpecDetail HeatPump { get; set; } = new();
        public SpecDetail V2lCapability { get; set; } = new(); // Vehicle-to-Load
    }
}
