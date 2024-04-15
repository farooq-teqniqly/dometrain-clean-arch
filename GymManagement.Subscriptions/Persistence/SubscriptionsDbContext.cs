using GymManagement.Subscriptions.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Subscriptions.Persistence;
internal class SubscriptionsDbContext(DbContextOptions<SubscriptionsDbContext> options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
}
