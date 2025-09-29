using System.Text.Json.Serialization;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SalesOrderStatus
    {
        Pending,
        Confirmed,
        Delivered,
        Canceled,
    }
}
