using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockChartingApp.CompanyMS.Migrations
{
    public partial class CreateContextDB_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockPrice");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "StockPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "StockPrice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "StockPrice");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "StockPrice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "StockPrice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
