using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merawo.Core.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: true),
                    SellingCountry = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    DocumentType = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(type: "varchar(255)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: true),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "SellingCountry", "Title" },
                values: new object[,]
                {
                    { 1, "France", "Renault" },
                    { 2, "USA", "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DocumentNumber", "DocumentType", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "9593278", "DNI", "Alexander", "Lugo" },
                    { 2, "14565987", "PASSPORT", "Mercky", "Velasquez" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "ClientId", "Date", "Detail" },
                values: new object[] { 1, 1, new DateTime(2024, 10, 11, 17, 46, 43, 556, DateTimeKind.Local).AddTicks(4866), "Purchase 1" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "ClientId", "Date", "Detail" },
                values: new object[] { 2, 2, new DateTime(2024, 10, 11, 17, 46, 43, 557, DateTimeKind.Local).AddTicks(7836), "Purchase 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "Cost", "IsActive", "PurchaseId", "Stock", "Title" },
                values: new object[] { 1, 1, 100m, true, 1, 50, "Clio" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "Cost", "IsActive", "PurchaseId", "Stock", "Title" },
                values: new object[] { 2, 2, 150m, true, 2, 30, "Fiesta" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseId",
                table: "Products",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
