
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRoles> AccountRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Post> Posts { get; set; }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "Administrator" });
    }

}
