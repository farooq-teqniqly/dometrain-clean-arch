using GymManagement.Subscriptions.Domain;

namespace GymManagement.Subscriptions.Repositories;

internal interface ISubscriptionReadRepository
{
    Task<Subscription> GetSubscription(Guid id);
    Task<IEnumerable<Subscription>> GetSubscriptions();
}
