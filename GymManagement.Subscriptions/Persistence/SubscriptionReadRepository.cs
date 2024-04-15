using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionReadRepository(SubscriptionsDbContext dbContext) : ISubscriptionReadRepository
{
    public async Task<Subscription> GetSubscription(Guid id)
    {
        //TODO: Make return type nullable.
        return (await dbContext.Subscriptions.FindAsync(id))!;
    }
}
