using Core.Entities;
using DataAccess.Concrete.EntityFramework.Config;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class RentACarContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    //public DbSet<Car> Cars { get; set; }

    public RentACarContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Brand>().HasKey(i=> i.Id); // EF Core Naming Convention BrandId
        modelBuilder.Entity<Brand>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Premium).HasDefaultValue(true);
        });
        modelBuilder.ApplyConfiguration(new RoleConfig());
        base.OnModelCreating(modelBuilder); // Normalde yaptığı işlemleri sürdürür.
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<Entity<int>>();
        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdateAt= DateTime.UtcNow,
            };
        };

        return await base.SaveChangesAsync(cancellationToken);
    }
}
// Update-Database migrationIsmi
// Remove-Migration

// 17:45