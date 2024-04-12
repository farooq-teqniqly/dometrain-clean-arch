using Ardalis.Result;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Commands;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<Result<Guid>>;

public class CreateSubscriptionCommandHandler(ISubscriptionWriteService subscriptionWriteService) : IRequestHandler<CreateSubscriptionCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var newSubscriptionId = subscriptionWriteService.CreateSubscription(request.SubscriptionType, request.AdminId);
        return Task.FromResult<Result<Guid>>(newSubscriptionId);
    }
}
