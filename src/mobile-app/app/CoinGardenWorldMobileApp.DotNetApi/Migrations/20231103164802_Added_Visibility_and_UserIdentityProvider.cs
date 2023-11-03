using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinGardenWorldMobileApp.DotNetApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_Visibility_and_UserIdentityProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("44dbc2e7-4dfb-42cf-b080-0f17fb5e03b6"));

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Gardens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Flowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserIdentityProvider",
                table: "Accounts",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedFrom", "CreatedOn", "DeletedAt", "DeletedFrom", "Description", "Name", "UpdatedFrom", "UpdatedOn" },
                values: new object[] { new Guid("1e6e0b25-9e66-41c8-a2a2-f8ad0f289b9e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2023, 11, 3, 16, 48, 2, 316, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Administrator", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e6e0b25-9e66-41c8-a2a2-f8ad0f289b9e"));

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "UserIdentityProvider",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedFrom", "CreatedOn", "DeletedAt", "DeletedFrom", "Description", "Name", "UpdatedFrom", "UpdatedOn" },
                values: new object[] { new Guid("44dbc2e7-4dfb-42cf-b080-0f17fb5e03b6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2023, 11, 3, 15, 21, 24, 510, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Administrator", null, null });
        }
    }
}
