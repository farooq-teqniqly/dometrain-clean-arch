using System.Net;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using GymManagement.Contracts.Subscriptions;

namespace GymManagement.Api.Tests.EndpointTests;
public class SubscriptionEndpointTests(ApiTestFixture fixture) : TestBase<ApiTestFixture>
{
    [Fact]
    public async Task Can_Create_Subscription()
    {
        var adminId = new Guid("091c08d9-1343-4a25-b7e6-3c9a4d70d9d2");
        var request = new CreateSubscriptionRequest(SubscriptionType.Free, adminId);

        var (httpResponse, epResponse) = await fixture.Client
            .POSTAsync<CreateSubscriptionEndpoint, CreateSubscriptionRequest, CreateSubscriptionResponse>(
                request);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

        var expectedSubscriptionId = new Guid("d85fe8a0-f857-4391-a138-3479c903ba80");

        epResponse.Id.Should().Be(expectedSubscriptionId);
        epResponse.SubscriptionType.Should().Be(request.SubscriptionType);
    }
}
