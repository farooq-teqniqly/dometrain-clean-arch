﻿using System.Net;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Endpoints;

namespace GymManagement.Api.Tests.EndpointTests;

[Collection("IntegrationTests")]
public class SubscriptionEndpointTests(ApiTestFixture fixture) : TestBase<ApiTestFixture>
{
    [Fact]
    public async Task Can_Create_And_Get_Subscription()
    {
        var adminId = Guid.NewGuid();
        var request = new CreateSubscriptionRequest(SubscriptionType.Pro, adminId);

        var (createSubscriptionHttpResponse, createdSubscriptionEpResponse) = await fixture.Client
            .POSTAsync<CreateSubscriptionEndpoint, CreateSubscriptionRequest, CreateSubscriptionResponse>(
        request);

        createSubscriptionHttpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdSubscriptionId =
            new Guid(createSubscriptionHttpResponse.Headers.Location!.ToString().Split("/")[^1]);

        createdSubscriptionId.Should().NotBe(default(Guid));

        var newSubscription = createdSubscriptionEpResponse;

        var (getSubscriptionHttpResponse, getSubscriptionEpResponse) = await fixture.Client
            .GETAsync<GetSubscriptionEndpoint, GetSubscriptionRequest, GetSubscriptionResponse>(
                new GetSubscriptionRequest(newSubscription.Id));

        getSubscriptionHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var retrievedSubscription = getSubscriptionEpResponse;
        retrievedSubscription.Type.Should().Be(SubscriptionType.Pro);
    }

    [Fact]
    public async Task Created_Subscription_Response_Has_Subscription_Id_In_Location_Header()
    {
        var adminId = Guid.NewGuid();
        var request = new CreateSubscriptionRequest(SubscriptionType.Pro, adminId);

        var (createSubscriptionHttpResponse, _) = await fixture.Client
            .POSTAsync<CreateSubscriptionEndpoint, CreateSubscriptionRequest, CreateSubscriptionResponse>(
                request);

        var createdSubscriptionId =
            new Guid(createSubscriptionHttpResponse.Headers.Location!.ToString().Split("/")[^1]);

        createdSubscriptionId.Should().NotBe(default(Guid));
    }

    [Fact]
    public async Task Can_Get_All_Subscriptions()
    {
        var (_, getExistingSubscriptionSListEpResponse) = await fixture.Client
            .GETAsync<GetSubscriptionsListEndpoint, GetSubscriptionsListResponse>();

        var existingSubscriptions = getExistingSubscriptionSListEpResponse.Subscriptions.ToList();

        var adminId = Guid.NewGuid();

        var subscriptionsToCreate = new List<Subscription>
        {
            new(adminId, SubscriptionType.Free),
            new(adminId, SubscriptionType.Starter),
            new(adminId, SubscriptionType.Pro)
        };

        foreach (var subscription in subscriptionsToCreate)
        {
            var request = new CreateSubscriptionRequest(subscription.Type, adminId);

            await fixture.Client
                .POSTAsync<CreateSubscriptionEndpoint, CreateSubscriptionRequest, CreateSubscriptionResponse>(
                    request);
        }

        var (getSubscriptionsListHttpResponse, getSubscriptionSListEpResponse) = await fixture.Client
            .GETAsync<GetSubscriptionsListEndpoint, GetSubscriptionsListResponse>();

        getSubscriptionsListHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var retrievedSubscriptions = getSubscriptionSListEpResponse.Subscriptions
            .Except(existingSubscriptions)
            .OrderBy(s => s.Type)
            .ToList();

        retrievedSubscriptions.Count.Should().Be(3);

        for (var i = 0; i < retrievedSubscriptions.Count; i++)
        {
            retrievedSubscriptions[i].Type.Should().Be(subscriptionsToCreate[i].Type);
        }

    }
}
