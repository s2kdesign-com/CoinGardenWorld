using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoinGardenWorldMobileApp.DotNetApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProfileIntroduction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfilePicure = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BadgeType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountExternalLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ObjectIdAzureAd = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IdentityProvider = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExternalLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountExternalLogins_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gardens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountBadges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BadgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBadges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBadges_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountBadges_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flowers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flowers_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    LinkOrImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    GardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FlowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostType = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedOn", "DeletedAt", "DisplayName", "Email", "ProfileIntroduction", "ProfilePicure", "UpdatedOn", "Username" },
                values: new object[] { new Guid("8303bd79-e268-4768-8aba-2e8ca97a90a2"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 0, 0, 0, 0)), null, "CoinGarden.World", "coingardenworld@gmail.com", null, null, null, null });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "BadgeType", "CreatedOn", "DeletedAt", "Description", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("03e2cf5e-946a-45df-b3b0-cb1483c43e6c"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 0, 0, 0, 0)), null, "This badge is given to all new members as a welcome gesture, symbolizing the potential and growth that awaits them in the community.", "Recruit Rosebud (Upon Registration)", null },
                    { new Guid("087ec3f5-093b-4a80-b611-cdd5a992eae0"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6007), new TimeSpan(0, 0, 0, 0, 0)), null, "This badge, given at four years, signifies the member's high quality and valuable contributions, akin to the highly prized teak wood.", "Perennial Teak Colonel (4 Years of Membership)", null },
                    { new Guid("105598a1-a8a9-4cc7-8b22-7cb18c557b4e"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 0, 0, 0, 0)), null, "This prestigious badge is for users who have uploaded 1000 flowers, recognizing their abundant contributions that have enriched the community with fragrance and beauty.", "General Gardenia (1000 flowers)", null },
                    { new Guid("14b42f8c-c68c-47d2-add9-55861d2977d3"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6008), new TimeSpan(0, 0, 0, 0, 0)), null, "After five years, members are honored with this badge, representing their robust and steadfast support of the community, much like the mighty oak tree.", "Oak Brigadier (5 Years of Membership)", null },
                    { new Guid("2560e599-f003-434b-8fc6-ed324f0e973b"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6004), new TimeSpan(0, 0, 0, 0, 0)), null, "At three years, this badge represents the member's towering achievements and their evergreen contributions, which remain constant throughout the seasons.", "Triennial Pine Major (3 Years of Membership)", null },
                    { new Guid("2b42f3ef-3ac7-425c-8980-b4a866c3a844"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 0, 0, 0, 0)), null, "With 400 flowers contributed, this badge acknowledges the user's flexibility and strength, reflecting the bamboo's qualities of rapid growth and versatility.", "Brigadier Bamboo (400 flowers)", null },
                    { new Guid("30c92d7c-d495-4009-a740-1b13e065c0a1"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 0, 0, 0, 0)), null, "Celebrating one year of membership, this badge is awarded to those who have shown leadership and have become a stable force within the community, much like the ash tree.", "Annual Birch Lieutenant (1 Year of Membership)", null },
                    { new Guid("37801f4c-7903-46f5-aad2-99aff95f4590"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 0, 0, 0, 0)), null, "This badge is given to those who have contributed 20 flowers, representing their calming influence and the trust they've cultivated within the community.", "Lieutenant Lavender (20 flowers)", null },
                    { new Guid("4b20d730-806e-421c-bcaa-d885761b76dd"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 0, 0, 0, 0)), null, "Awarded after uploading five flowers, this badge recognizes the user's growing contributions and their budding presence in the community.", "Corporal Clusters (5 flowers)", null },
                    { new Guid("5153b088-863d-4905-8b60-b79dd6eacf3c"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 0, 0, 0, 0)), null, "This initial badge is for those who have shared their first flower, taking the first step in contributing to the community's beauty and diversity.", "Private Petal (1 flower)", null },
                    { new Guid("57b2df87-efb0-411b-a9d7-7f9fd2d52099"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 0, 0, 0, 0)), null, "After two years, members receive this badge, representing their evergreen contributions that keep the community vibrant throughout the seasons.", "Biannual Ash Captain (2 Years of Membership)", null },
                    { new Guid("623fb503-e72d-4e61-b655-eaa59b4b84fb"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(6013), new TimeSpan(0, 0, 0, 0, 0)), null, "At six years, this prestigious badge is awarded to members who have shown leadership and a strong foundation of support, embodying the cedar's stature and longevity.", "Cedar General (6 Years of Membership)", null },
                    { new Guid("686a2b9b-2e42-4ddd-b29a-7f0aeb140131"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 0, 0, 0, 0)), null, "For users who reach the 100-flower mark, this badge celebrates their significant and dignified contributions that add a touch of southern elegance to the community.", "Major Magnolia (100 flowers)", null },
                    { new Guid("7040aba9-b94b-4393-bf89-7a24c8568b9d"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 0, 0, 0, 0)), null, "Recognizing a significant milestone of 50 flowers, this badge honors the user's bold and impactful contributions that stand out in the community.", "Captain Carnation (50 flowers)", null },
                    { new Guid("790fe26a-1012-4852-b734-f5f2aff1f7b8"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 0, 0, 0, 0)), null, "The highest honor, this badge is bestowed upon users who have uploaded over 2000 flowers, symbolizing their unparalleled commitment to cultivating a diverse and thriving community ecosystem.", "Field Marshal Flora (2000+ flowers)", null },
                    { new Guid("8b1949c9-0504-482b-b40a-27c2367990e1"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 0, 0, 0, 0)), null, "At the six-month mark, members are recognized with this badge, symbolizing their adaptability and bright presence in the community, reminiscent of the birch tree's ability to thrive in various conditions.", "Seasonal Spruce Sergeant (Six months of Membership)", null },
                    { new Guid("96695787-c8b9-432a-8633-02be2e8f87c4"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 0, 0, 0, 0)), null, "For users who have uploaded ten flowers, this badge symbolizes their commitment to nurturing the community's growth and the sprouting of new ideas and connections.", "Sergeant Sprout (10 flowers)", null },
                    { new Guid("b069ac51-8f73-498f-b770-ef087c55ab55"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 0, 0, 0, 0)), null, "After a month, members receive this badge, symbolizing the steady and robust growth akin to a maple tree, laying the foundation for future contributions.", "Month Willow Private (One month of Membership)", null },
                    { new Guid("d38a3bda-04f5-4eaa-9dad-a5832707a695"), 1, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 0, 0, 0, 0)), null, "This badge is awarded to those who have uploaded 200 flowers, symbolizing their resilience and the enduring nature of their contributions, even in challenging environments.", "Colonel Cactus (200 flowers)", null },
                    { new Guid("e0c7b53a-43b3-4f16-bafd-671bc38dd964"), 0, new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5998), new TimeSpan(0, 0, 0, 0, 0)), null, "This badge is given after three months to recognize members who have started to stand tall in the community, much like a spruce tree, showing resilience and consistency.", "Quarterly Maple Corporal (Three months of Membership)", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "DeletedAt", "Description", "Name", "UpdatedOn", "Visibility" },
                values: new object[,]
                {
                    { new Guid("7e71bc48-bc89-469e-b05b-63b73e926461"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 0, 0, 0, 0)), null, null, "PremiumUser", null, 3 },
                    { new Guid("ad021a33-6f24-4d9d-9870-490cef797b48"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Administrator", null, 3 },
                    { new Guid("d34eef1b-8349-422b-ae84-9cd84f433e5b"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5883), new TimeSpan(0, 0, 0, 0, 0)), null, null, "StandardUser", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "AccountExternalLogins",
                columns: new[] { "Id", "AccountId", "CreatedOn", "DeletedAt", "DisplayName", "IdentityProvider", "ObjectIdAzureAd", "ProfilePictureUrl", "UpdatedOn" },
                values: new object[] { new Guid("6f81b635-6808-4251-948a-32e966657190"), new Guid("8303bd79-e268-4768-8aba-2e8ca97a90a2"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 0, 0, 0, 0)), null, "CoinGarden.World", "google.com", "b5f4562f-dd5a-475f-a638-8952423adc50", null, null });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "AccountId", "CreatedOn", "DeletedAt", "RoleId", "UpdatedOn" },
                values: new object[] { new Guid("0e4c8a00-0d2f-4f1d-ad67-dafd93efb2af"), new Guid("8303bd79-e268-4768-8aba-2e8ca97a90a2"), new DateTimeOffset(new DateTime(2023, 11, 5, 11, 0, 36, 562, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("ad021a33-6f24-4d9d-9870-490cef797b48"), null });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBadges_AccountId",
                table: "AccountBadges",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBadges_BadgeId",
                table: "AccountBadges",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExternalLogins_AccountId",
                table: "AccountExternalLogins",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_AccountId",
                table: "AccountRoles",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_AccountId",
                table: "Flowers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_GardenId",
                table: "Flowers",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_AccountId",
                table: "Gardens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountId",
                table: "Posts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FlowerId",
                table: "Posts",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GardenId",
                table: "Posts",
                column: "GardenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBadges");

            migrationBuilder.DropTable(
                name: "AccountExternalLogins");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
