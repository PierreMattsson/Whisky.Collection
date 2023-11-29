using Microsoft.EntityFrameworkCore;
using Whisky.Collection.Domain;
using Whisky.Collection.Domain.Common;

namespace WhiskyCollectionPersistence.DatabaseContext;

public class MyWhiskyDatabaseContext : DbContext
{
    public MyWhiskyDatabaseContext(DbContextOptions<MyWhiskyDatabaseContext> options) : base(options)
    {

    }

    public DbSet<MyWhisky> MyWhiskies { get; set; }
    public DbSet<MyCollection> myCollections { get; set; }
    public DbSet<MyPurchase> myPurchase { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyWhiskyDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Modifying the date so user don't need to input
        // Check if its a new date or update date
        // Then saves the date with the other changes that was made

        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.UpdatedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
