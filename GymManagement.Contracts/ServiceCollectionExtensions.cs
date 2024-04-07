using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Contracts;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddContractEndpoints(this IServiceCollection services)
    {
        services.AddFastEndpoints(o => o.Assemblies = new[] { typeof(ServiceCollectionExtensions).Assembly });
        return services;
    }
}
