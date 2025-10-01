namespace EVDMS.Common.Helpers
{
    public class VehicleSpecs
    {
        // Performance
        public SpecDetail? Horsepower { get; set; }
        public SpecDetail? Torque { get; set; }
        public SpecDetail? Acceleration { get; set; } // 0-100 km/h
        public SpecDetail? DriveType { get; set; }
        public SpecDetail? MotorType { get; set; }
        public SpecDetail? TopSpeed { get; set; }
        public SpecDetail? CurbWeight { get; set; }

        // Energy
        public SpecDetail? BatteryCapacity { get; set; }
        public SpecDetail? Range { get; set; }
        public SpecDetail? Efficiency { get; set; }
        public SpecDetail? BatteryChemistry { get; set; }
        public SpecDetail? BatteryVoltageArchitecture { get; set; }
        public SpecDetail? RegenerativeBrakingCapacity { get; set; }

        // Charging
        public SpecDetail? MaxAcChargingRate { get; set; }
        public SpecDetail? MaxDcFastChargingRate { get; set; }
        public SpecDetail? DcFastChargingTime { get; set; } // 10–80%
        public SpecDetail? AcChargingTime { get; set; } // 0–100%
        public SpecDetail? ChargingPortTypes { get; set; }

        // Practicality
        public SpecDetail? TowingCapacity { get; set; }
        public SpecDetail? FrunkVolume { get; set; }
        public SpecDetail? CargoVolume { get; set; }
        public SpecDetail? HeatPump { get; set; }
        public SpecDetail? V2lCapability { get; set; } // Vehicle-to-Load
    }
}
