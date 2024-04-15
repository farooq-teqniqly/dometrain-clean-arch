using Ardalis.Result;
using GymManagement.Services;
using GymManagement.Subscriptions.Repositories;
using MediatR;

namespace GymManagement.Subscriptions.Integrations.Commands;

public record DeleteSubscriptionCommand(Guid Id) : IRequest<Result>;

internal class DeleteSubscriptionCommandHandler(ISubscriptionWriteRepository writeRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteSubscriptionCommand, Result>
{
    public async Task<Result> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        await writeRepository.DeleteSubscription(request.Id);
        await unitOfWork.CommitChanges();
        return Result.Success();
    }
}
