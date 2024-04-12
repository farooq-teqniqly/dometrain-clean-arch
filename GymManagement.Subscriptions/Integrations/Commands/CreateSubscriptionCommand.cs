using MediatR;

namespace GymManagement.Subscriptions.Integrations.Commands;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<Guid>;

public class CreateSubscriptionCommandHandler(ISubscriptionWriteService subscriptionWriteService) : IRequestHandler<CreateSubscriptionCommand, Guid>
{
    public Task<Guid> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(subscriptionWriteService.CreateSubscription(request.SubscriptionType, request.AdminId));
    }
}
