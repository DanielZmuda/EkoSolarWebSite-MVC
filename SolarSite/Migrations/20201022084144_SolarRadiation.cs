using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarSite.Migrations
{
    public partial class SolarRadiation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolarRadiations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    M = table.Column<int>(nullable: false),
                    I_N_0 = table.Column<int>(nullable: false),
                    I_N__30 = table.Column<int>(nullable: false),
                    I_NE_30 = table.Column<int>(nullable: false),
                    I_E__30 = table.Column<int>(nullable: false),
                    I_SE_30 = table.Column<int>(nullable: false),
                    I_S__30 = table.Column<int>(nullable: false),
                    I_SW_30 = table.Column<int>(nullable: false),
                    I_W__30 = table.Column<int>(nullable: false),
                    I_NW_30 = table.Column<int>(nullable: false),
                    I_N__45 = table.Column<int>(nullable: false),
                    I_NE_45 = table.Column<int>(nullable: false),
                    I_E__45 = table.Column<int>(nullable: false),
                    I_SE_45 = table.Column<int>(nullable: false),
                    I_S__45 = table.Column<int>(nullable: false),
                    I_SW_45 = table.Column<int>(nullable: false),
                    I_W__45 = table.Column<int>(nullable: false),
                    I_NW_45 = table.Column<int>(nullable: false),
                    I_N__60 = table.Column<int>(nullable: false),
                    I_NE_60 = table.Column<int>(nullable: false),
                    I_E__60 = table.Column<int>(nullable: false),
                    I_SE_60 = table.Column<int>(nullable: false),
                    I_S__60 = table.Column<int>(nullable: false),
                    I_SW_60 = table.Column<int>(nullable: false),
                    I_W__60 = table.Column<int>(nullable: false),
                    I_NW_60 = table.Column<int>(nullable: false),
                    I_N__90 = table.Column<int>(nullable: false),
                    I_NE_90 = table.Column<int>(nullable: false),
                    I_E__90 = table.Column<int>(nullable: false),
                    I_SE_90 = table.Column<int>(nullable: false),
                    I_S__90 = table.Column<int>(nullable: false),
                    I_SW_90 = table.Column<int>(nullable: false),
                    I_W__90 = table.Column<int>(nullable: false),
                    I_NW_90 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarRadiations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolarRadiations");
        }
    }
}
