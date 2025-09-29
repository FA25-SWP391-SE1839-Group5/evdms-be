using System.Text.Json.Serialization;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FeedbackStatus
    {
        New,
        Reviewed,
        Resolved,
        Dismissed,
    }
}
