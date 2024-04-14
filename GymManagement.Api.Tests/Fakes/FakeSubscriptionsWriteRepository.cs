using GymManagement.Services;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;

namespace GymManagement.Api.Tests.Fakes;
internal class FakeSubscriptionsWriteRepository(IUnitOfWork unitOfWork) : ISubscriptionWriteRepository
{
    public async Task AddSubscription(Subscription subscription)
    {
        await unitOfWork.CommitChanges();
    }
}
