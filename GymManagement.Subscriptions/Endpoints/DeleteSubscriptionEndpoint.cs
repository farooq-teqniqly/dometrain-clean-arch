using FastEndpoints;
using GymManagement.Subscriptions.Integrations.Commands;
using MediatR;

namespace GymManagement.Subscriptions.Endpoints;
internal class DeleteSubscriptionEndpoint(ISender mediator) : Endpoint<DeleteSubscriptionRequest>
{
    public override void Configure()
    {
        Delete("api/subscriptions/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteSubscriptionRequest req, CancellationToken ct)
    {
        var command = new DeleteSubscriptionCommand(req.Id);
        await mediator.Send(command, ct);
        await SendNoContentAsync(ct);
    }
}

internal record DeleteSubscriptionRequest(Guid Id);

