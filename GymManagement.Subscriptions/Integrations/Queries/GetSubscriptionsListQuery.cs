using Ardalis.Result;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Queries;

internal record GetSubscriptionsListQuery : IRequest<Result<IEnumerable<Subscription>>>;

internal class GetSubscriptionsListQueryHandler(ISubscriptionReadRepository subscriptionReadRepository)
    : IRequestHandler<GetSubscriptionsListQuery, Result<IEnumerable<Subscription>>>
{
    public async Task<Result<IEnumerable<Subscription>>> Handle(GetSubscriptionsListQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await subscriptionReadRepository.GetSubscriptions();
        return Result<IEnumerable<Subscription>>.Success(subscriptions);
    }
}
