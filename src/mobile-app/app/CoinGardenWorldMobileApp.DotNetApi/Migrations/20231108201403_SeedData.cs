using System.Text.Json;
using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinGardenWorldMobileApp.DotNetApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Seed Badges
            var badges = new List<Badge>();
            var badgeAdmin = new Badge();

            // Seed GardenBadges.SpeciallyAssignedBadges
            foreach (var badgeName in GardenBadges.SpeciallyAssignedBadges.BadgeNames)
            {
                if (badgeName.Item3.Contains("System Administrator"))
                {
                    badgeAdmin = new Badge
                    {
                        Id = badgeAdmin.Id,
                        Icon = badgeName.Item1,
                        Color = badgeName.Item2,
                        Name = badgeName.Item3,
                        Description = badgeName.Item4,
                        BadgeType = GardenBadges.SpeciallyAssignedBadges.BadgeType
                    };

                    badges.Add(badgeAdmin);

                }
                else
                {
                    badges.Add(new Badge
                    {
                        Id = Guid.NewGuid(),
                        Icon = badgeName.Item1,
                        Color = badgeName.Item2,
                        Name = badgeName.Item3,
                        Description = badgeName.Item4,
                        BadgeType = GardenBadges.SpeciallyAssignedBadges.BadgeType
                    });
                }
            }

            // Seed GardenBadges.BadgesBasedOnUploadsCount
            foreach (var badgeName in GardenBadges.BadgesBasedOnUploadsCount.BadgeNames)
            {
                badges.Add(new Badge
                {
                    Id = Guid.NewGuid(),
                    Icon = GardenBadges.BadgesBasedOnUploadsCount.BadgeIconName,
                    Color = GardenBadges.BadgesBasedOnUploadsCount.BadgeColor,
                    Name = badgeName.Key,
                    Description = badgeName.Value,
                    BadgeType = GardenBadges.BadgesBasedOnUploadsCount.BadgeType
                });
            }
            // Seed GardenBadges.BadgesBasedOnTimeRegistered
            foreach (var badgeName in GardenBadges.BadgesBasedOnTimeRegistered.BadgeNames)
            {
                badges.Add(new Badge
                {
                    Id = Guid.NewGuid(),
                    Icon = GardenBadges.BadgesBasedOnTimeRegistered.BadgeIconName,
                    Color = GardenBadges.BadgesBasedOnTimeRegistered.BadgeColor,
                    Name = badgeName.Key,
                    Description = badgeName.Value,
                    BadgeType = GardenBadges.BadgesBasedOnTimeRegistered.BadgeType
                });
            }

            foreach (var badge in badges)
            {

                migrationBuilder.InsertData(
                    table: "Badges",
                    columns: new[] { "Id", "BadgeType", "Name", "Icon", "Color", "Description", "CreatedOn" },
                    values: new object[]
                    {
                         badge.Id,
                         (int) badge.BadgeType,
                         badge.Name,
                         badge.Icon,
                         badge.Color,
                         badge.Description,
                         badge.CreatedOn
                                    });
            }

            var account = new Account
            {
                Email = "coingardenworld@gmail.com",
                Username = "CoinGardenWorld",
                DisplayName = "CoinGarden.World",
            };

            var roleAdmin = new Role { Name = "Administrator" };
            var roleAdminJson = JsonSerializer.Serialize(new List<AccountRole> { new AccountRole { RoleId = roleAdmin.Id, RoleName = roleAdmin.Name, AssignedOn = roleAdmin.CreatedOn } });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "DisplayName", "Email", "Username", "CreatedOn" },
                values: new object[] {
                     account.Id,
                     account.DisplayName,
                     account.Email,
                     account.Username,
                     account.CreatedOn
                                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "Visibility", "CreatedOn" },
                values: new object[,]
                {
                     { Guid.NewGuid(), "PremiumUser", (int) Visibility.Public,
                         roleAdmin.CreatedOn },
                     { Guid.NewGuid(), "StandardUser", (int)  Visibility.Public,
                         roleAdmin.CreatedOn },
                     { roleAdmin.Id, roleAdmin.Name, (int)  Visibility.Public,
                         roleAdmin.CreatedOn }
                });

            migrationBuilder.Sql($"UPDATE [dbo].[Accounts] SET [Roles] = '{roleAdminJson}' ");

            var accountBadges = new List<AccountBadge> {
                new AccountBadge
                {
                    BadgeId = badgeAdmin.Id,
                    BadgeName = badgeAdmin.Name,
                    BadgeColor = badgeAdmin.Color,
                    BadgeIcon = badgeAdmin.Icon,
                    EarnedOn = badgeAdmin.CreatedOn
                }
            };
            var accountBadgesJson = JsonSerializer.Serialize(accountBadges);
            migrationBuilder.Sql($"UPDATE [dbo].[Accounts] SET [Badges] = '{accountBadgesJson}' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
