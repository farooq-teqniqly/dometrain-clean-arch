using FastEndpoints;
using FastEndpoints.Swagger;
using GymManagement.Contracts;
using Serilog;

namespace GymManagement.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var logger = Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        logger.Information("Starting GymManagement.Api...");

        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

        builder.Services.AddScoped<ITimeService, TimeService>();

        builder.Services
            .AddFastEndpoints()
            .AddContractEndpoints()
            .SwaggerDocument();

        var app = builder.Build();

        app.UseFastEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerGen();
        }

        app.Run();
    }
}
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
internal record PingResponse(string Message, string ApiVersion, long Timestamp);

internal class TimeService : ITimeService
{
    public long GetUnixTimestamp() => (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
}

