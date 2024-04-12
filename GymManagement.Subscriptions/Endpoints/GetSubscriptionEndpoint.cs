using FastEndpoints;

namespace GymManagement.Subscriptions.Endpoints;
internal class GetSubscriptionEndpoint : Endpoint<GetSubscriptionRequest, GetSubscriptionResponse>
{
    public override void Configure()
    {
        Get("api/subscriptions/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetSubscriptionRequest req, CancellationToken ct)
    {
        await SendOkAsync(new GetSubscriptionResponse(SubscriptionType.Pro), ct);
    }
}

internal record GetSubscriptionRequest(Guid Id);
internal record GetSubscriptionResponse(SubscriptionType Type);
