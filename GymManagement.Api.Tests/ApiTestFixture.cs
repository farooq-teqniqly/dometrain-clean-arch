using FastEndpoints.Testing;
using GymManagement.Api.Tests.Fakes;
using GymManagement.Services;
using GymManagement.Subscriptions.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Api.Tests;

public class ApiTestFixture : AppFixture<Program>
{
    protected override void ConfigureApp(IWebHostBuilder a)
    {
        a.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<SubscriptionsDbContext>(opts => opts.UseSqlite());

        ApplyDatabaseMigrations(services);

        services.AddScoped<ITimeService, FakeTimeService>();
        services.AddSingleton<IIdService, IdService>();
    }

    private void ApplyDatabaseMigrations(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var subscriptionsDbContext = scope.ServiceProvider.GetRequiredService<SubscriptionsDbContext>();

        if (File.Exists(subscriptionsDbContext.Database.GetDbConnection().DataSource))
        {
            File.Delete(subscriptionsDbContext.Database.GetDbConnection().DataSource);
        }

        subscriptionsDbContext.Database.Migrate();
    }
}
