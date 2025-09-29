using System.Text.Json.Serialization;

namespace EVDMS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        BankTransfer,
        Financing,
    }
}
