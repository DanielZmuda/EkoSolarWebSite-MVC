using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarSite.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PvPanels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(nullable: true),
                    Moc = table.Column<double>(nullable: false),
                    Typ = table.Column<string>(nullable: true),
                    Wysokosc = table.Column<double>(nullable: false),
                    Szerokosc = table.Column<double>(nullable: false),
                    Grubosc = table.Column<double>(nullable: false),
                    Waga = table.Column<double>(nullable: false),
                    Wydajnosc = table.Column<double>(nullable: false),
                    Zdjecie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PvPanels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPvPanel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    PvPanelId = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPvPanel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPvPanel_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPvPanel_PvPanels_PvPanelId",
                        column: x => x.PvPanelId,
                        principalTable: "PvPanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPvPanel_OrderId",
                table: "OrderPvPanel",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPvPanel_PvPanelId",
                table: "OrderPvPanel",
                column: "PvPanelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPvPanel");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PvPanels");
        }
    }
}
