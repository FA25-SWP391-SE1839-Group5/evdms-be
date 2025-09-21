using EVDMS.DataAccessLayer.Data.Seeds.SeedIds;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class FeatureSeed
    {
        public static List<Feature> Features =>
            [
                // Convenience
                new Feature
                {
                    Id = FeatureIds.AdaptiveCruiseControl,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Adaptive Cruise Control",
                },
                new Feature
                {
                    Id = FeatureIds.CooledSeats,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Cooled Seats",
                },
                new Feature
                {
                    Id = FeatureIds.HeatedSeats,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Heated Seats",
                },
                new Feature
                {
                    Id = FeatureIds.HeatedSteeringWheel,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Heated Steering Wheel",
                },
                new Feature
                {
                    Id = FeatureIds.KeylessEntry,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Keyless Entry",
                },
                new Feature
                {
                    Id = FeatureIds.KeylessStart,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Keyless Start",
                },
                new Feature
                {
                    Id = FeatureIds.NavigationSystem,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Navigation System",
                },
                new Feature
                {
                    Id = FeatureIds.RemoteStart,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Remote Start",
                },
                new Feature
                {
                    Id = FeatureIds.PowerLiftgate,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Power Liftgate",
                },
                new Feature
                {
                    Id = FeatureIds.RainSensingWipers,
                    CategoryId = FeatureCategoryIds.Convenience,
                    FeatureName = "Rain Sensing Wipers",
                },
                // Entertainment
                new Feature
                {
                    Id = FeatureIds.AndroidAuto,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "Android Auto®",
                },
                new Feature
                {
                    Id = FeatureIds.AppleCarPlay,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "Apple CarPlay®",
                },
                new Feature
                {
                    Id = FeatureIds.Bluetooth,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "Bluetooth®",
                },
                new Feature
                {
                    Id = FeatureIds.HomeLink,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "HomeLink",
                },
                new Feature
                {
                    Id = FeatureIds.PremiumSoundSystem,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "Premium Sound System",
                },
                new Feature
                {
                    Id = FeatureIds.USBPort,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "USB Port",
                },
                new Feature
                {
                    Id = FeatureIds.WiFiHotspot,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "WiFi Hotspot",
                },
                new Feature
                {
                    Id = FeatureIds.SatelliteRadio,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "Satellite Radio",
                },
                new Feature
                {
                    Id = FeatureIds.CDPlayer,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "CD Player",
                },
                new Feature
                {
                    Id = FeatureIds.AUXInput,
                    CategoryId = FeatureCategoryIds.Entertainment,
                    FeatureName = "AUX Input",
                },
                // Exterior
                new Feature
                {
                    Id = FeatureIds.AlloyWheels,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Alloy Wheels",
                },
                new Feature
                {
                    Id = FeatureIds.TowHitch,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Tow Hitch",
                },
                new Feature
                {
                    Id = FeatureIds.TowHooks,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Tow Hooks",
                },
                new Feature
                {
                    Id = FeatureIds.FogLights,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Fog Lights",
                },
                new Feature
                {
                    Id = FeatureIds.RoofRails,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Roof Rails",
                },
                new Feature
                {
                    Id = FeatureIds.Sunroof,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Sunroof",
                },
                new Feature
                {
                    Id = FeatureIds.PowerMirrors,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Power Mirrors",
                },
                new Feature
                {
                    Id = FeatureIds.RearSpoiler,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Rear Spoiler",
                },
                new Feature
                {
                    Id = FeatureIds.AutomaticHeadlights,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Automatic Headlights",
                },
                new Feature
                {
                    Id = FeatureIds.DaytimeRunningLights,
                    CategoryId = FeatureCategoryIds.Exterior,
                    FeatureName = "Daytime Running Lights",
                },
                // Safety
                new Feature
                {
                    Id = FeatureIds.AutomaticEmergencyBraking,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Automatic Emergency Braking",
                },
                new Feature
                {
                    Id = FeatureIds.BackupCamera,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Backup Camera",
                },
                new Feature
                {
                    Id = FeatureIds.BlindSpotMonitor,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Blind Spot Monitor",
                },
                new Feature
                {
                    Id = FeatureIds.BrakeAssist,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Brake Assist",
                },
                new Feature
                {
                    Id = FeatureIds.LEDHeadlights,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "LED Headlights",
                },
                new Feature
                {
                    Id = FeatureIds.LaneDepartureWarning,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Lane Departure Warning",
                },
                new Feature
                {
                    Id = FeatureIds.RearCrossTrafficAlert,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Rear Cross Traffic Alert",
                },
                new Feature
                {
                    Id = FeatureIds.StabilityControl,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Stability Control",
                },
                new Feature
                {
                    Id = FeatureIds.TractionControl,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Traction Control",
                },
                new Feature
                {
                    Id = FeatureIds.ParkingSensors,
                    CategoryId = FeatureCategoryIds.Safety,
                    FeatureName = "Parking Sensors",
                },
                // Seating
                new Feature
                {
                    Id = FeatureIds.LeatherSeats,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Leather Seats",
                },
                new Feature
                {
                    Id = FeatureIds.MemorySeat,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Memory Seat",
                },
                new Feature
                {
                    Id = FeatureIds.PowerDriverSeat,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Power Driver Seat",
                },
                new Feature
                {
                    Id = FeatureIds.PowerPassengerSeat,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Power Passenger Seat",
                },
                new Feature
                {
                    Id = FeatureIds.HeatedRearSeats,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Heated Rear Seats",
                },
                new Feature
                {
                    Id = FeatureIds.VentilatedSeats,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Ventilated Seats",
                },
                new Feature
                {
                    Id = FeatureIds.SplitFoldingRearSeat,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Split Folding Rear Seat",
                },
                new Feature
                {
                    Id = FeatureIds.AdjustableLumbarSupport,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Adjustable Lumbar Support",
                },
                new Feature
                {
                    Id = FeatureIds.BucketSeats,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Bucket Seats",
                },
                new Feature
                {
                    Id = FeatureIds.ThirdRowSeating,
                    CategoryId = FeatureCategoryIds.Seating,
                    FeatureName = "Third Row Seating",
                },
            ];
    }
}
