using System.Text.Json.Serialization;
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
        var response = new CreateSubscriptionResponse(idService.CreateId(), req.Type);
        await SendCreatedAtAsync<GetSubscriptionEndpoint>(new { response.Id }, response, cancellation: ct);
    }
}

internal record CreateSubscriptionResponse(Guid Id, SubscriptionType Type);

internal record CreateSubscriptionRequest(SubscriptionType Type, Guid AdminId);

[JsonConverter(typeof(JsonStringEnumConverter))]
internal enum SubscriptionType
{
    Free = 0,
    Starter,
    Pro
}
