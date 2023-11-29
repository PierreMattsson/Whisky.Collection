using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiskyCollectionPersistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyWhiskies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProducerName = table.Column<string>(type: "TEXT", nullable: false),
                    WhiskyName = table.Column<string>(type: "TEXT", nullable: false),
                    WhiskyYearStatement = table.Column<int>(type: "INTEGER", nullable: false),
                    BottleDescription = table.Column<string>(type: "TEXT", nullable: false),
                    AlkoholProcent = table.Column<double>(type: "REAL", nullable: false),
                    BottleContentMilliliter = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyWhiskies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "myCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TasteDescription = table.Column<string>(type: "TEXT", nullable: false),
                    WhiskyId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_myCollections_MyWhiskies_WhiskyId",
                        column: x => x.WhiskyId,
                        principalTable: "MyWhiskies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "myPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PurchaseCost = table.Column<int>(type: "INTEGER", nullable: false),
                    WhiskyId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_myPurchase_MyWhiskies_WhiskyId",
                        column: x => x.WhiskyId,
                        principalTable: "MyWhiskies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MyWhiskies",
                columns: new[] { "Id", "AlkoholProcent", "BottleContentMilliliter", "BottleDescription", "CreatedDate", "ProducerName", "UpdatedDate", "WhiskyName", "WhiskyYearStatement" },
                values: new object[] { 1, 40.0, 700, "Highland Single Malt Scotch Whisky", new DateTime(2023, 11, 29, 16, 33, 29, 685, DateTimeKind.Local).AddTicks(7865), "Macallan", new DateTime(2023, 11, 29, 16, 33, 29, 685, DateTimeKind.Local).AddTicks(7912), "Double Cask", 12 });

            migrationBuilder.CreateIndex(
                name: "IX_myCollections_WhiskyId",
                table: "myCollections",
                column: "WhiskyId");

            migrationBuilder.CreateIndex(
                name: "IX_myPurchase_WhiskyId",
                table: "myPurchase",
                column: "WhiskyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myCollections");

            migrationBuilder.DropTable(
                name: "myPurchase");

            migrationBuilder.DropTable(
                name: "MyWhiskies");
        }
    }
}
