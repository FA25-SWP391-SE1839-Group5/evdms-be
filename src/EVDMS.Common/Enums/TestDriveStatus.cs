using System.Text.Json.Serialization;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TestDriveStatus
    {
        Scheduled,
        Completed,
        Canceled,
        NoShow,
    }
}
