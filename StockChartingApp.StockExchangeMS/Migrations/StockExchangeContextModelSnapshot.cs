﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockChartingApp.StockExchangeMS.Models;

namespace StockChartingApp.StockExchangeMS.Migrations
{
    [DbContext(typeof(StockExchangeContext))]
    partial class StockExchangeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLibraryStockChartingApp.BoardMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoardMember");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BusinessSectorId")
                        .HasColumnType("int");

                    b.Property<string>("Ceo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Turnover")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BusinessSectorId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.IPODetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OfferingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("PricePerShare")
                        .HasColumnType("float");

                    b.Property<int?>("RegisteredCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("RegisteredStockExchangeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalShares")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredCompanyId");

                    b.HasIndex("RegisteredStockExchangeId");

                    b.ToTable("IPODetails");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.JoinCompanyBoardMember", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("BoardMemberId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId", "BoardMemberId");

                    b.HasIndex("BoardMemberId");

                    b.ToTable("JoinCompanyBoardMember");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.JoinCompanyStockExchange", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("StockExchangeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CompanyId", "StockExchangeId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("JoinCompanyStockExchange");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.StockExchange", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExchangeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StockExchange");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("StockExchangeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("StockPrice");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.Company", b =>
                {
                    b.HasOne("EntityLibraryStockChartingApp.Sector", "BusinessSector")
                        .WithMany("Companies")
                        .HasForeignKey("BusinessSectorId");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.IPODetails", b =>
                {
                    b.HasOne("EntityLibraryStockChartingApp.Company", "RegisteredCompany")
                        .WithMany("Ipos")
                        .HasForeignKey("RegisteredCompanyId");

                    b.HasOne("EntityLibraryStockChartingApp.StockExchange", "RegisteredStockExchange")
                        .WithMany("Ipos")
                        .HasForeignKey("RegisteredStockExchangeId");
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.JoinCompanyBoardMember", b =>
                {
                    b.HasOne("EntityLibraryStockChartingApp.BoardMember", "BoardMember")
                        .WithMany("JoinCompanyBod")
                        .HasForeignKey("BoardMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLibraryStockChartingApp.Company", "Company")
                        .WithMany("JoinCompanyBod")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.JoinCompanyStockExchange", b =>
                {
                    b.HasOne("EntityLibraryStockChartingApp.Company", "Company")
                        .WithMany("JoinCompanyExchanges")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLibraryStockChartingApp.StockExchange", "StockExchange")
                        .WithMany("JoinCompanyExchanges")
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLibraryStockChartingApp.StockPrice", b =>
                {
                    b.HasOne("EntityLibraryStockChartingApp.Company", "RegisteredCompany")
                        .WithMany("CurrentPrices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLibraryStockChartingApp.StockExchange", "RegisteredStockExchange")
                        .WithMany("CurrentPrices")
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
