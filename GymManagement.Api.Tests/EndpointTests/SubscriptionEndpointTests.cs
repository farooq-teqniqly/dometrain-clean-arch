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

        epResponse.Id.Should().NotBe(Guid.Empty);
        epResponse.SubscriptionType.Should().Be(SubscriptionType.Free);
    }
}
