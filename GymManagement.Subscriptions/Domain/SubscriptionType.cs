using System.Text.Json.Serialization;

namespace GymManagement.Subscriptions.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionType
{
    Free = 0,
    Starter,
    Pro
}
