using GymManagement.Services;
using GymManagement.Subscriptions.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Subscriptions.Persistence;
internal class SubscriptionsDbContext(DbContextOptions<SubscriptionsDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public async Task CommitChanges()
    {
        await base.SaveChangesAsync();
    }
}
