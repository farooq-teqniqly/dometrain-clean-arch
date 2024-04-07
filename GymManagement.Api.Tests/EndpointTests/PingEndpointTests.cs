using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;

namespace GymManagement.Api.Tests.EndpointTests;
public class PingEndpointTests(ApiTestFixture fixture) : TestBase<ApiTestFixture>
{
    [Fact]
    public async Task Ping_Returns_Expected_Response()
    {
        var (httpResponse, epResponse) = await fixture.Client.GETAsync<PingEndpoint, PingResponse>();

        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        epResponse.Message.Should().Be("GymManagement API says hello.");
        epResponse.ApiVersion.Should().Be("1.0.0");
        epResponse.Timestamp.Should().BeGreaterThanOrEqualTo(0);
    }
}
