using System.Reflection;
using GymManagement.Services;
using GymManagement.Subscriptions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Subscriptions.Persistence;
internal class SubscriptionsDbContext(DbContextOptions<SubscriptionsDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public async Task CommitChanges()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();

        builder.Property(s => s.Type).HasConversion(
            type => type.Value,
            value => SubscriptionType.FromValue(value));
    }
}
