using System.Text.Json.Serialization;

namespace EVDMS.Common.Helpers
{
    public class SpecDetail
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Value { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Unit { get; set; }
    }
}
