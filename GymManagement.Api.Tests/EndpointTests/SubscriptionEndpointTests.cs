﻿using System.Net;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using GymManagement.Subscriptions.Domain;
using GymManagement.Subscriptions.Endpoints;

namespace GymManagement.Api.Tests.EndpointTests;
public class SubscriptionEndpointTests(ApiTestFixture fixture) : TestBase<ApiTestFixture>
{
    [Fact]
    public async Task Can_Create_And_Get_Subscription()
    {
        var adminId = new Guid("091c08d9-1343-4a25-b7e6-3c9a4d70d9d2");
        var request = new CreateSubscriptionRequest(SubscriptionType.Pro, adminId);

        var (createSubscriptionHttpResponse, createdSubscriptionEpResponse) = await fixture.Client
            .POSTAsync<CreateSubscriptionEndpoint, CreateSubscriptionRequest, CreateSubscriptionResponse>(
        request);

        createSubscriptionHttpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

        var expectedSubscriptionId = new Guid("d85fe8a0-f857-4391-a138-3479c903ba80");

        createSubscriptionHttpResponse.Headers.Location.Should().Be($"/api/subscriptions/{expectedSubscriptionId}");

        var newSubscription = createdSubscriptionEpResponse;
        
        var (getSubscriptionHttpResponse, getSubscriptionEpResponse) = await fixture.Client
            .GETAsync<GetSubscriptionEndpoint, GetSubscriptionRequest, GetSubscriptionResponse>(
                new GetSubscriptionRequest(newSubscription.Id));

        getSubscriptionHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);


        var retrievedSubscription = getSubscriptionEpResponse;
        retrievedSubscription.Type.Should().Be(SubscriptionType.Pro);
    }
}
