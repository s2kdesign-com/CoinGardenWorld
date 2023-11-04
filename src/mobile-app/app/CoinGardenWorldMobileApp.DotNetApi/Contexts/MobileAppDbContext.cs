
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRoles> AccountRoles { get; set; }
    public DbSet<AccountExternalLogins> AccountExternalLogins { get; set; }
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
        var roleId = Guid.NewGuid();
        var accountId = Guid.NewGuid();

        // Add Your admin account here from Azure AD B2C / Users
        modelBuilder.Entity<Account>().HasData(new Account { Id = accountId, DisplayName = "CoinGarden.World", Email = "coingardenworld@gmail.com" });

        modelBuilder.Entity<AccountExternalLogins>().HasData(new AccountExternalLogins { AccountId = accountId, DisplayName = "CoinGarden.World", ObjectIdAzureAd = "b5f4562f-dd5a-475f-a638-8952423adc50", IdentityProvider = "google.com" });

        modelBuilder.Entity<Role>().HasData(new Role { Id = roleId, Name = "Administrator", Visibility = Visibility.Private });

        modelBuilder.Entity<AccountRoles>().HasData(new AccountRoles { Id = Guid.NewGuid(), AccountId = accountId, RoleId = roleId });

    }

}
