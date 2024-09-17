using System.Text.Json.Serialization;

namespace TesteTopDownContract.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionType
    {
        Basic,
        Pro,
    }
}
