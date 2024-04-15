using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Subscriptions.Persistence;

internal class SubscriptionReadRepository(SubscriptionsDbContext dbContext) : ISubscriptionReadRepository
{
    public async Task<Subscription> GetSubscription(Guid id)
    {
        //TODO: Make return type nullable.
        return (await dbContext.Subscriptions.FindAsync(id))!;
    }

    public async Task<IEnumerable<Subscription>> GetSubscriptions()
    {
        return await dbContext.Subscriptions.ToListAsync();
    }
}
