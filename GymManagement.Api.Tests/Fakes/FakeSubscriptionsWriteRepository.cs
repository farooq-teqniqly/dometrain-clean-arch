using GymManagement.Services;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Api.Tests.Fakes;
internal class FakeSubscriptionsWriteRepository(IIdService idService) : ISubscriptionWriteRepository
{
    public Task AddSubscription(Subscription subscription)
    {
        return Task.FromResult(new Subscription(idService.CreateId()));
    }
}
