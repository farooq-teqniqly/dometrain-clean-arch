using System.Net;
using FastEndpoints;
using GymManagement.Services;

namespace GymManagement.Contracts.Subscriptions;

internal class CreateSubscriptionEndpoint(IIdService idService) : Endpoint<CreateSubscriptionRequest, CreateSubscriptionResponse>
{
    public override void Configure()
    {
        Post("api/subscriptions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSubscriptionRequest req, CancellationToken ct)
    {
        var response = new CreateSubscriptionResponse(idService.CreateId(), req.SubscriptionType);
        await SendAsync(response, (int)HttpStatusCode.Created, ct);
    }
}

internal record CreateSubscriptionResponse(Guid Id, SubscriptionType SubscriptionType);

internal record CreateSubscriptionRequest(SubscriptionType SubscriptionType, Guid AdminId);

internal enum SubscriptionType
{
    Free = 0,
    Starter,
    Pro
}
