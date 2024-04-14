using GymManagement.Subscriptions.Domain;

namespace GymManagement.Subscriptions.Repositories;
public interface ISubscriptionWriteRepository
{
    Task AddSubscription(Subscription subscription);
}

internal class SubscriptionWriteRepository : ISubscriptionWriteRepository
{
    public Task AddSubscription(Subscription subscription)
    {
        return Task.CompletedTask;
    }
}
