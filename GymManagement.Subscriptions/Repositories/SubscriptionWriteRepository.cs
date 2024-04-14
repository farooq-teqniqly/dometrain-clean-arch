using GymManagement.Subscriptions.Domain;

namespace GymManagement.Subscriptions.Repositories;

internal class SubscriptionWriteRepository : ISubscriptionWriteRepository
{
    public Task AddSubscription(Subscription subscription)
    {
        return Task.CompletedTask;
    }
}
