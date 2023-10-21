
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Flower> Flowers { get; set; }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
