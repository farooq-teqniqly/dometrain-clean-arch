using System.Collections.Concurrent;
using GymManagement.Subscriptions.Domain;

namespace GymManagement.Subscriptions.Persistence;

internal static class InMemoryDatabase
{
    private static readonly ConcurrentBag<Subscription> _subscriptions = [];

    public static void AddSubscription(Subscription subscription)
    {
        if (_subscriptions.Any(s => s.Id == subscription.Id))
        {
            return;
        }

        _subscriptions.Add(subscription);
    }

    public static Subscription GetSubscription(Guid id)
    {
        return _subscriptions.Single(s => s.Id == id);
    }
}
