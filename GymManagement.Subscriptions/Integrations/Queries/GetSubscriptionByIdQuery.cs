using Ardalis.Result;
using GymManagement.Subscriptions.Domain;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Queries;

public record GetSubscriptionByIdQuery(Guid Id) : IRequest<Result<Subscription>>;

internal class GetSubscriptionByIdQueryHandler() : IRequestHandler<GetSubscriptionByIdQuery, Result<Subscription>>
{
    public Task<Result<Subscription>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription(new Guid("d85fe8a0-f857-4391-a138-3479c903ba80"), SubscriptionType.Pro);
        return Task.FromResult(Result<Subscription>.Success(subscription));
    }
}
