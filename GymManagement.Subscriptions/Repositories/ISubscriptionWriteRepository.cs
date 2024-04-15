using GymManagement.Subscriptions.Domain;

namespace GymManagement.Subscriptions.Repositories;
internal interface ISubscriptionWriteRepository
{
    Task AddSubscription(Subscription subscription);
    Task DeleteSubscription(Guid id);
}
