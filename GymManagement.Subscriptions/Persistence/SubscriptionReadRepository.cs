using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionReadRepository : ISubscriptionReadRepository
{
    public Task<Subscription> GetSubscription(Guid id)
    {
        return Task.FromResult(InMemoryDatabase.GetSubscription(id));
    }
}
