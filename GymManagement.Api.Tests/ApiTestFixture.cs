using FastEndpoints.Testing;
using Microsoft.AspNetCore.Hosting;

namespace GymManagement.Api.Tests;

public class ApiTestFixture: AppFixture<Program>
{
    protected override void ConfigureApp(IWebHostBuilder a)
    {
        a.UseContentRoot(Directory.GetCurrentDirectory());
    }


}
