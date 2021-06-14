using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingHunting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fishing",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FishingProductName = table.Column<string>(nullable: true),
                    FishingProductType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FishingPlace",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FishingPlaceName = table.Column<string>(nullable: true),
                    FishingLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingPlace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hunting",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    HuntingProductName = table.Column<string>(nullable: true),
                    HuntingProductType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hunting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HuntingPlace",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    HuntingPlaceName = table.Column<string>(nullable: true),
                    HuntingLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingPlace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    HuntingPlaceID = table.Column<Guid>(nullable: true),
                    FishingPlaceID = table.Column<Guid>(nullable: true),
                    UserID = table.Column<Guid>(nullable: true),
                    FishingProductID = table.Column<Guid>(nullable: true),
                    HuntingProductID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Preferences_FishingPlace_FishingPlaceID",
                        column: x => x.FishingPlaceID,
                        principalTable: "FishingPlace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_Fishing_FishingProductID",
                        column: x => x.FishingProductID,
                        principalTable: "Fishing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_HuntingPlace_HuntingPlaceID",
                        column: x => x.HuntingPlaceID,
                        principalTable: "HuntingPlace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_Hunting_HuntingProductID",
                        column: x => x.HuntingProductID,
                        principalTable: "Hunting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_FishingPlaceID",
                table: "Preferences",
                column: "FishingPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_FishingProductID",
                table: "Preferences",
                column: "FishingProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_HuntingPlaceID",
                table: "Preferences",
                column: "HuntingPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_HuntingProductID",
                table: "Preferences",
                column: "HuntingProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UserID",
                table: "Preferences",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "FishingPlace");

            migrationBuilder.DropTable(
                name: "Fishing");

            migrationBuilder.DropTable(
                name: "HuntingPlace");

            migrationBuilder.DropTable(
                name: "Hunting");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
