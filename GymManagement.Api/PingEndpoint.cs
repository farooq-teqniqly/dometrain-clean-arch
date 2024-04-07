using FastEndpoints;
using GymManagement.Services;

namespace GymManagement.Api;

internal class PingEndpoint(ITimeService timeService) : EndpointWithoutRequest<PingResponse>
{
    public override void Configure()
    {
        Get("api/ping");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(new PingResponse("GymManagement API says hello.", "1.0.0", timeService.GetUnixTimestamp()), ct);
    }
}