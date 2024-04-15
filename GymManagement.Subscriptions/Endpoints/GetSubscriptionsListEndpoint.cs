using FastEndpoints;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Integrations.Queries;
using MediatR;

namespace GymManagement.Subscriptions.Endpoints;
internal class GetSubscriptionsListEndpoint(ISender mediator) : EndpointWithoutRequest<GetSubscriptionsListResponse>
{
    public override void Configure()
    {
        Get("api/subscriptions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetSubscriptionsListQuery();
        var queryResult = await mediator.Send(query, ct);
        await SendOkAsync(new GetSubscriptionsListResponse(queryResult.Value), ct);
    }
}

internal record GetSubscriptionsListResponse(IEnumerable<Subscription> Subscriptions);
