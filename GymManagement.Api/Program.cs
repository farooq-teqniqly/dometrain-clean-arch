using FastEndpoints;
using FastEndpoints.Swagger;
using GymManagement.Services;
using GymManagement.Subscriptions;
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
        builder.Services.AddSingleton<IIdService, IdService>();

        builder.Services
            .AddFastEndpoints()
            .AddSubscriptionEndpoints()
            .AddSubscriptionServices()
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
