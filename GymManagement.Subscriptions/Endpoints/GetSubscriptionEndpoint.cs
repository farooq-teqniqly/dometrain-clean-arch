using FastEndpoints;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Integrations.Queries;
using MediatR;

namespace GymManagement.Subscriptions.Endpoints;
internal class GetSubscriptionEndpoint(ISender mediator) : Endpoint<GetSubscriptionRequest, GetSubscriptionResponse>
{
    public override void Configure()
    {
        Get("api/subscriptions/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetSubscriptionRequest req, CancellationToken ct)
    {
        var query = new GetSubscriptionByIdQuery(req.Id);
        var queryResult = await mediator.Send(query, ct);
        var subscription = queryResult.Value;
        await SendOkAsync(new GetSubscriptionResponse(subscription.Type, subscription.AdminId), ct);
    }
}

internal record GetSubscriptionRequest(Guid Id);
internal record GetSubscriptionResponse(SubscriptionType Type, Guid AdminId);
