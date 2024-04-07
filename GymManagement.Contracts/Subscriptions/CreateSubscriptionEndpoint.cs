using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FastEndpoints;

namespace GymManagement.Contracts.Subscriptions;

internal class CreateSubscriptionEndpoint : Endpoint<CreateSubscriptionRequest, CreateSubscriptionResponse>
{
    public override void Configure()
    {
        Post("api/subscriptions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSubscriptionRequest req, CancellationToken ct)
    {
        var response = new CreateSubscriptionResponse(Guid.NewGuid(), req.SubscriptionType);
        await SendAsync(response, (int)HttpStatusCode.Created, ct);
    }
}

internal record CreateSubscriptionResponse(Guid Id, string SubscriptionType);

internal record CreateSubscriptionRequest(string SubscriptionType, Guid AdminId);

internal static class SubscriptionType
{
    public static string Free = "Free";
}
