using FastEndpoints;
using GymManagement.Services;
using GymManagement.Subscriptions.Persistence;
using GymManagement.Subscriptions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Subscriptions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSubscriptionEndpoints(this IServiceCollection services)
    {
        services.AddFastEndpoints(o => o.Assemblies = new[] { typeof(ServiceCollectionExtensions).Assembly });
        return services;
    }

    public static IServiceCollection AddSubscriptionServices(this IServiceCollection services)
    {
        services.AddDbContext<SubscriptionsDbContext>(opts =>
        {
            opts.UseSqlite("Data Source=GymManagement.db");
        });

        services.AddScoped<ISubscriptionWriteRepository, SubscriptionWriteRepository>();
        services.AddScoped<ISubscriptionReadRepository, SubscriptionReadRepository>();
        services.AddMediatR();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SubscriptionsDbContext>());

        return services;
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(opts =>
            opts.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));

    }
}
