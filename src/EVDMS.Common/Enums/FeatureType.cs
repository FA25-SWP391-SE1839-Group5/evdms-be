using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FeatureType
    {
        AdaptiveCruiseControl,
        AdjustableLumbarSupport,
        AlloyWheels,
        AndroidAuto,
        AppleCarPlay,
        AutomaticEmergencyBraking,
        AutomaticHeadlights,
        AuxInput,
        BackupCamera,
        BlindSpotMonitor,
        Bluetooth,
        BrakeAssist,
        BucketSeats,
        CooledSeats,
        DaytimeRunningLights,
        FogLights,
        HeatedRearSeats,
        HeatedSeats,
        HeatedSteeringWheel,
        HomeLink,
        KeylessEntry,
        KeylessStart,
        LaneDepartureWarning,
        LeatherSeats,
        LedHeadlights,
        MemorySeat,
        NavigationSystem,
        ParkingSensors,
        PowerDriverSeat,
        PowerLiftgate,
        PowerMirrors,
        PowerPassengerSeat,
        PremiumSoundSystem,
        RainSensingWipers,
        RearCrossTrafficAlert,
        RearSpoiler,
        RoofRails,
        SatelliteRadio,
        SplitFoldingRearSeat,
        StabilityControl,
        Sunroof,
        ThirdRowSeating,
        TowHitch,
        TractionControl,
        UsbPort,
        VentilatedSeats,
        WifiHotspot,
    }
}
