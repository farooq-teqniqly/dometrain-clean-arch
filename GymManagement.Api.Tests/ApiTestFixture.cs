using FastEndpoints.Testing;
using GymManagement.Api.Tests.Fakes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Api.Tests;

public class ApiTestFixture: AppFixture<Program>
{
    protected override void ConfigureApp(IWebHostBuilder a)
    {
        a.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        s.AddScoped<ITimeService, FakeTimeService>();
    }
}
