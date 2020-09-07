using Microsoft.EntityFrameworkCore.Migrations;

namespace StockChartingApp.SectorMS.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_Company_RegisteredCompanyId",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_StockExchange_RegisteredStockExchangeId",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinCompanyStockExchange_StockExchange_StockExchangeId1",
                table: "JoinCompanyStockExchange");

            migrationBuilder.DropIndex(
                name: "IX_JoinCompanyStockExchange_StockExchangeId1",
                table: "JoinCompanyStockExchange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IPODetails",
                table: "IPODetails");

            migrationBuilder.DropIndex(
                name: "IX_IPODetails_RegisteredCompanyId",
                table: "IPODetails");

            migrationBuilder.DropColumn(
                name: "StockExchangeId1",
                table: "JoinCompanyStockExchange");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IPODetails");

            migrationBuilder.AlterColumn<string>(
                name: "StockExchangeId",
                table: "JoinCompanyStockExchange",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RegisteredStockExchangeId",
                table: "IPODetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCompanyId",
                table: "IPODetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IPODetails",
                table: "IPODetails",
                columns: new[] { "RegisteredCompanyId", "RegisteredStockExchangeId" });

            migrationBuilder.CreateIndex(
                name: "IX_JoinCompanyStockExchange_StockExchangeId",
                table: "JoinCompanyStockExchange",
                column: "StockExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_Company_RegisteredCompanyId",
                table: "IPODetails",
                column: "RegisteredCompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_StockExchange_RegisteredStockExchangeId",
                table: "IPODetails",
                column: "RegisteredStockExchangeId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinCompanyStockExchange_StockExchange_StockExchangeId",
                table: "JoinCompanyStockExchange",
                column: "StockExchangeId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_Company_RegisteredCompanyId",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_StockExchange_RegisteredStockExchangeId",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinCompanyStockExchange_StockExchange_StockExchangeId",
                table: "JoinCompanyStockExchange");

            migrationBuilder.DropIndex(
                name: "IX_JoinCompanyStockExchange_StockExchangeId",
                table: "JoinCompanyStockExchange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IPODetails",
                table: "IPODetails");

            migrationBuilder.AlterColumn<int>(
                name: "StockExchangeId",
                table: "JoinCompanyStockExchange",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeId1",
                table: "JoinCompanyStockExchange",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisteredStockExchangeId",
                table: "IPODetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCompanyId",
                table: "IPODetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IPODetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IPODetails",
                table: "IPODetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JoinCompanyStockExchange_StockExchangeId1",
                table: "JoinCompanyStockExchange",
                column: "StockExchangeId1");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_RegisteredCompanyId",
                table: "IPODetails",
                column: "RegisteredCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_Company_RegisteredCompanyId",
                table: "IPODetails",
                column: "RegisteredCompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_StockExchange_RegisteredStockExchangeId",
                table: "IPODetails",
                column: "RegisteredStockExchangeId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinCompanyStockExchange_StockExchange_StockExchangeId1",
                table: "JoinCompanyStockExchange",
                column: "StockExchangeId1",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
