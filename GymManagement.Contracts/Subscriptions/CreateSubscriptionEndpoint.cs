using System.Net;
using FastEndpoints;

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

internal interface IIdService
{
    Guid CreateId();
}

internal record CreateSubscriptionResponse(Guid Id, SubscriptionType SubscriptionType);

internal record CreateSubscriptionRequest(SubscriptionType SubscriptionType, Guid AdminId);

internal enum SubscriptionType
{
    Free
}
