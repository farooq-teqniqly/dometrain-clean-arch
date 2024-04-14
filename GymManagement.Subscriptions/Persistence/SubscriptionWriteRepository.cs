using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionWriteRepository : ISubscriptionWriteRepository
{
    private static readonly List<Subscription> _subscriptions = [];

    public Task AddSubscription(Subscription subscription)
    {
        _subscriptions.Add(subscription);
        return Task.CompletedTask;
    }
}
