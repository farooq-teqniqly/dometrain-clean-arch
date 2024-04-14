using Ardalis.Result;
using GymManagement.Services;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Repositories;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Commands;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<Result<Subscription>>;

internal class CreateSubscriptionCommandHandler(ISubscriptionWriteRepository writeRepository, IIdService idService) : IRequestHandler<CreateSubscriptionCommand, Result<Subscription>>
{
    public async Task<Result<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var newSubscription = new Subscription(idService.CreateId());
        await writeRepository.AddSubscription(newSubscription);
        //await unitOfWork.CommitChanges();

        return Result<Subscription>.Success(newSubscription);
    }
}
