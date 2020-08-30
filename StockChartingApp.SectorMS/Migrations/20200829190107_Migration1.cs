using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockChartingApp.SectorMS.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockExchange",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ExchangeName = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    Turnover = table.Column<double>(nullable: false),
                    Ceo = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: false),
                    BusinessSectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Sector_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IPODetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerShare = table.Column<double>(nullable: false),
                    TotalShares = table.Column<int>(nullable: false),
                    OfferingDateTime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    RegisteredCompanyId = table.Column<int>(nullable: true),
                    RegisteredStockExchangeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPODetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPODetails_Company_RegisteredCompanyId",
                        column: x => x.RegisteredCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IPODetails_StockExchange_RegisteredStockExchangeId",
                        column: x => x.RegisteredStockExchangeId,
                        principalTable: "StockExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JoinCompanyBoardMember",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    BoardMemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinCompanyBoardMember", x => new { x.CompanyId, x.BoardMemberId });
                    table.ForeignKey(
                        name: "FK_JoinCompanyBoardMember_BoardMember_BoardMemberId",
                        column: x => x.BoardMemberId,
                        principalTable: "BoardMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinCompanyBoardMember_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoinCompanyStockExchange",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    StockExchangeId = table.Column<int>(nullable: false),
                    StockExchangeId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinCompanyStockExchange", x => new { x.CompanyId, x.StockExchangeId });
                    table.ForeignKey(
                        name: "FK_JoinCompanyStockExchange_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinCompanyStockExchange_StockExchange_StockExchangeId1",
                        column: x => x.StockExchangeId1,
                        principalTable: "StockExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    StockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPrice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockPrice_StockExchange_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_BusinessSectorId",
                table: "Company",
                column: "BusinessSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_RegisteredCompanyId",
                table: "IPODetails",
                column: "RegisteredCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_RegisteredStockExchangeId",
                table: "IPODetails",
                column: "RegisteredStockExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinCompanyBoardMember_BoardMemberId",
                table: "JoinCompanyBoardMember",
                column: "BoardMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinCompanyStockExchange_StockExchangeId1",
                table: "JoinCompanyStockExchange",
                column: "StockExchangeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrice_CompanyId",
                table: "StockPrice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrice_StockExchangeId",
                table: "StockPrice",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPODetails");

            migrationBuilder.DropTable(
                name: "JoinCompanyBoardMember");

            migrationBuilder.DropTable(
                name: "JoinCompanyStockExchange");

            migrationBuilder.DropTable(
                name: "StockPrice");

            migrationBuilder.DropTable(
                name: "BoardMember");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "StockExchange");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
