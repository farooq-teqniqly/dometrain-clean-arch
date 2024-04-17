using FastEndpoints;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Integrations.Commands;
using MediatR;

namespace GymManagement.Subscriptions.Endpoints;

internal class CreateSubscriptionEndpoint(ISender mediator) : Endpoint<CreateSubscriptionRequest, CreateSubscriptionResponse>
{
    public override void Configure()
    {
        Post("api/subscriptions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSubscriptionRequest req, CancellationToken ct)
    {
        var subscriptionType = SubscriptionType.FromName(req.Type);
        var command = new CreateSubscriptionCommand(subscriptionType, req.AdminId);
        var createSubscriptionResult = await mediator.Send(command, ct);
        var createdSubscription = createSubscriptionResult.Value;
        var response = new CreateSubscriptionResponse(createdSubscription.Id, createdSubscription.Type.Name);
        await SendCreatedAtAsync<GetSubscriptionEndpoint>(new { response.Id }, response, cancellation: ct);
    }
}

internal record CreateSubscriptionResponse(Guid Id, string Type);

internal record CreateSubscriptionRequest(string Type, Guid AdminId);
