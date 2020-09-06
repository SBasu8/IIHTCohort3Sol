using Microsoft.EntityFrameworkCore.Migrations;

namespace StockChartingApp.CompanyMS.Migrations
{
    public partial class CreateContextDB_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Sector_BusinessSectorId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_BusinessSectorId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "BusinessSectorId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Company",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Company_SectorId",
                table: "Company",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Sector_SectorId",
                table: "Company",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Sector_SectorId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_SectorId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "BusinessSectorId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_BusinessSectorId",
                table: "Company",
                column: "BusinessSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Sector_BusinessSectorId",
                table: "Company",
                column: "BusinessSectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
