using Ardalis.Result;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Queries;

public record GetSubscriptionByIdQuery(Guid Id) : IRequest<Result<Subscription>>;

internal class GetSubscriptionByIdQueryHandler(ISubscriptionReadRepository subscriptionReadRepository) : IRequestHandler<GetSubscriptionByIdQuery, Result<Subscription>>
{
    public async Task<Result<Subscription>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionReadRepository.GetSubscription(request.Id);

        return subscription is null ? Result<Subscription>.NotFound() : Result<Subscription>.Success(subscription);
    }
}
