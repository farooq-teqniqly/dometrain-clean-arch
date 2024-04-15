using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionWriteRepository : ISubscriptionWriteRepository
{
    

    public Task AddSubscription(Subscription subscription)
    {
        InMemoryDatabase.AddSubscription(subscription);
        return Task.CompletedTask;
    }
}
