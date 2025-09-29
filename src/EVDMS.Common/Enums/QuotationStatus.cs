using System.Text.Json.Serialization;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuotationStatus
    {
        Draft,
        Sent,
        Approved,
        Rejected,
    }
}
