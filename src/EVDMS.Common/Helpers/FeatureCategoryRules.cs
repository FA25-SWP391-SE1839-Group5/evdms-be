using EVDMS.Common.Enums;

namespace EVDMS.Common.Helpers
{
    public static class FeatureCategoryRules
    {
        public static readonly HashSet<FeatureType> Safety =
        [
            FeatureType.AutomaticEmergencyBraking,
            FeatureType.BackupCamera,
            FeatureType.BlindSpotMonitor,
            FeatureType.BrakeAssist,
            FeatureType.LedHeadlights,
            FeatureType.LaneDepartureWarning,
            FeatureType.RearCrossTrafficAlert,
            FeatureType.StabilityControl,
            FeatureType.TractionControl,
            FeatureType.ParkingSensors,
        ];

        public static readonly HashSet<FeatureType> Convenience =
        [
            FeatureType.AdaptiveCruiseControl,
            FeatureType.CooledSeats,
            FeatureType.HeatedSeats,
            FeatureType.HeatedSteeringWheel,
            FeatureType.KeylessEntry,
            FeatureType.KeylessStart,
            FeatureType.NavigationSystem,
            FeatureType.PowerLiftgate,
            FeatureType.RainSensingWipers,
        ];

        public static readonly HashSet<FeatureType> Entertainment =
        [
            FeatureType.AndroidAuto,
            FeatureType.AppleCarPlay,
            FeatureType.Bluetooth,
            FeatureType.HomeLink,
            FeatureType.PremiumSoundSystem,
            FeatureType.UsbPort,
            FeatureType.WifiHotspot,
            FeatureType.SatelliteRadio,
            FeatureType.AuxInput,
        ];

        public static readonly HashSet<FeatureType> Exterior =
        [
            FeatureType.AlloyWheels,
            FeatureType.TowHitch,
            FeatureType.FogLights,
            FeatureType.RoofRails,
            FeatureType.Sunroof,
            FeatureType.PowerMirrors,
            FeatureType.RearSpoiler,
            FeatureType.AutomaticHeadlights,
            FeatureType.DaytimeRunningLights,
        ];

        public static readonly HashSet<FeatureType> Seating =
        [
            FeatureType.LeatherSeats,
            FeatureType.MemorySeat,
            FeatureType.PowerDriverSeat,
            FeatureType.PowerPassengerSeat,
            FeatureType.HeatedRearSeats,
            FeatureType.VentilatedSeats,
            FeatureType.SplitFoldingRearSeat,
            FeatureType.AdjustableLumbarSupport,
            FeatureType.BucketSeats,
            FeatureType.ThirdRowSeating,
        ];
    }
}
