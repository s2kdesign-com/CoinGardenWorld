﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinGardenWorldMobileApp.DotNetApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProfileIntroduction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfilePicure = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_CreatedFrom",
                        column: x => x.CreatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_UpdatedFrom",
                        column: x => x.UpdatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Gardens_Accounts_CreatedFrom",
                        column: x => x.CreatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gardens_Accounts_UpdatedFrom",
                        column: x => x.UpdatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flowers_Accounts_CreatedFrom",
                        column: x => x.CreatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flowers_Accounts_UpdatedFrom",
                        column: x => x.UpdatedFrom,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flowers_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatedFrom",
                table: "Accounts",
                column: "CreatedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UpdatedFrom",
                table: "Accounts",
                column: "UpdatedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_CreatedFrom",
                table: "Flowers",
                column: "CreatedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_GardenId",
                table: "Flowers",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_UpdatedFrom",
                table: "Flowers",
                column: "UpdatedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_AccountId",
                table: "Gardens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_CreatedFrom",
                table: "Gardens",
                column: "CreatedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UpdatedFrom",
                table: "Gardens",
                column: "UpdatedFrom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
