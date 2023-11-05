
using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountExternalLogins> AccountExternalLogins { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AccountRoles> AccountRoles { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<AccountBadges> AccountBadges { get; set; }

    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Post> Posts { get; set; }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Account>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<Role>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<AccountRoles>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<Badge>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<AccountBadges>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<AccountExternalLogins>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

        var roleId = Guid.NewGuid();
        var accountId = Guid.NewGuid();

        // Add Your admin account here from Azure AD B2C / Users
        modelBuilder.Entity<Account>().HasData(new Account { Id = accountId, DisplayName = "CoinGarden.World", Email = "coingardenworld@gmail.com" });

        modelBuilder.Entity<AccountExternalLogins>().HasData(new AccountExternalLogins { Id=Guid.NewGuid(), AccountId = accountId, DisplayName = "CoinGarden.World", ObjectIdAzureAd = "b5f4562f-dd5a-475f-a638-8952423adc50", IdentityProvider = "google.com" });

        modelBuilder.Entity<Role>().HasData(new Role { Id = roleId, Name = "Administrator", Visibility = Visibility.Private });

        modelBuilder.Entity<AccountRoles>().HasData(new AccountRoles { Id = Guid.NewGuid(), AccountId = accountId, RoleId = roleId });

        modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "StandardUser", Visibility = Visibility.Private });

        modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "PremiumUser", Visibility = Visibility.Private });

        // Seed Badges
        List<Badge> badges = new List<Badge>();
        // Seed GardenBadges.BadgesBasedOnUploadsCount
        foreach (var badgeName in GardenBadges.BadgesBasedOnUploadsCount.BadgeNames)
        {
            badges.Add(new Badge
            {
                Id = Guid.NewGuid(),
                Name = badgeName.Key,
                Description = badgeName.Value,
                BadgeType = BadgeTypes.BasedOnUploadsCount
            });
        }
        // Seed GardenBadges.BadgesBasedOnTimeRegistered
        foreach (var badgeName in GardenBadges.BadgesBasedOnTimeRegistered.BadgeNames)
        {
            badges.Add(new Badge
            {
                Id = Guid.NewGuid(),
                Name = badgeName.Key,
                Description = badgeName.Value,
                BadgeType = BadgeTypes.BasedOnTimeRegistered
            });
        }
        modelBuilder.Entity<Badge>().HasData(
            badges
        );
    }

}
