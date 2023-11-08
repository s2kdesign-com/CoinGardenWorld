
using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountExternalLogins> AccountExternalLogins { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Badge> Badges { get; set; }

    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<ProfilePicture> ProfilePictures { get; set; }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Configure Entities

        modelBuilder
            .Entity<Account>()
            .OwnsMany(e => e.Roles, builder => { builder.ToJson(); })
            .OwnsMany(e => e.Badges, builder => { builder.ToJson(); })
            .OwnsOne(e => e.ProfilePicture, builder => { builder.ToJson(); })
            ;

        modelBuilder
            .Entity<Flower>()
            .OwnsMany(e => e.Images, builder => { builder.ToJson(); });

        modelBuilder
            .Entity<Post>()
            .OwnsMany(e => e.Images, builder => { builder.ToJson(); });

        modelBuilder
            .Entity<ProfilePicture>()
            .OwnsOne(e => e.Image, builder => { builder.ToJson(); });

        #endregion


        #region Seed Data

        //var roleId = Guid.Parse("6BD20F1F-C9F7-4BC1-9151-0AFB8EF474C8");
        //var accountId = Guid.Parse("820746E9-B266-4313-BB95-FB073A4606EC");

        //// TODO: Add Your admin account here from Azure AD B2C / Users
        //modelBuilder.Entity<Account>().HasData(
        //    new Account
        //    {
        //        Id = accountId,
        //        DisplayName = "CoinGarden.World",
        //        Email = "coingardenworld@gmail.com",
        //        // TODO:  EF Core not supporting json seed https://github.com/dotnet/efcore/issues/29297
        //       // Roles = new List<AccountRoles> { new AccountRoles { RoleId = roleId, RoleName = "Administrator" } }
        //    });

        ////modelBuilder.Entity<AccountExternalLogins>().HasData(new AccountExternalLogins { AccountId = accountId, DisplayName = "CoinGarden.World", ObjectIdAzureAd = "b5f4562f-dd5a-475f-a638-8952423adc50", IdentityProvider = "google.com" });

        //modelBuilder.Entity<Role>().HasData(new Role { Id = roleId, Name = "Administrator", Visibility = Visibility.Private });

        //modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "StandardUser", Visibility = Visibility.Private });

        //modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "PremiumUser", Visibility = Visibility.Private });

        // Seed Badges
        //List<Badge> badges = new List<Badge>();
        //// Seed GardenBadges.BadgesBasedOnUploadsCount
        //foreach (var badgeName in GardenBadges.BadgesBasedOnUploadsCount.BadgeNames)
        //{
        //    badges.Add(new Badge
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = badgeName.Key,
        //        Description = badgeName.Value,
        //        BadgeType = BadgeTypes.BasedOnUploadsCount
        //    });
        //}
        //// Seed GardenBadges.BadgesBasedOnTimeRegistered
        //foreach (var badgeName in GardenBadges.BadgesBasedOnTimeRegistered.BadgeNames)
        //{
        //    badges.Add(new Badge
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = badgeName.Key,
        //        Description = badgeName.Value,
        //        BadgeType = BadgeTypes.BasedOnTimeRegistered
        //    });
        //}
        //modelBuilder.Entity<Badge>().HasData(
        //    badges
        //);

        #endregion
    }

}
