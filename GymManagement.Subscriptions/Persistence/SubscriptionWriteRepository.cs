using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionWriteRepository(SubscriptionsDbContext dbContext) : ISubscriptionWriteRepository
{


    public async Task AddSubscription(Subscription subscription)
    {
        await dbContext.AddAsync(subscription);
    }
}
