﻿using System.Text.Json.Serialization;
using FastEndpoints;
using GymManagement.Subscriptions.Commands;
using MediatR;

namespace GymManagement.Subscriptions;

internal class CreateSubscriptionEndpoint(ISender mediator) : Endpoint<CreateSubscriptionRequest, CreateSubscriptionResponse>
{
    public override void Configure()
    {
        Post("api/subscriptions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSubscriptionRequest req, CancellationToken ct)
    {
        var command = new CreateSubscriptionCommand(req.Type.ToString(), req.AdminId);
        var newSubscriptionId = await mediator.Send(command, ct);
        var response = new CreateSubscriptionResponse(newSubscriptionId!, req.Type);
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
