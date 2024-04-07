using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Subscriptions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSubscriptionEndpoints(this IServiceCollection services)
    {
        services.AddFastEndpoints(o => o.Assemblies = new[] { typeof(ServiceCollectionExtensions).Assembly });
        return services;
    }
}
