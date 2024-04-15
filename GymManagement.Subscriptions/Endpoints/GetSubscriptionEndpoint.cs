using FastEndpoints;
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
        await SendOkAsync(new GetSubscriptionResponse(SubscriptionType.Pro), ct);
    }
}

internal record GetSubscriptionRequest(Guid Id);
internal record GetSubscriptionResponse(SubscriptionType Type);
