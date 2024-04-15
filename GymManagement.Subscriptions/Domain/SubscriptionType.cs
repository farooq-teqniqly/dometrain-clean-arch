using System.Text.Json.Serialization;

namespace GymManagement.Subscriptions.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
internal enum SubscriptionType
{
    Free = 0,
    Starter,
    Pro
}
