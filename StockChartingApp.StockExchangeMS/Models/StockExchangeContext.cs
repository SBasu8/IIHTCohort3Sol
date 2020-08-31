using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Models
{
    public class StockExchangeContext : DbContext
    {

        public StockExchangeContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public StockExchangeContext()
        {
        }
        //Important for many many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinCompanyBoardMember>().HasKey(jcb => new { jcb.CompanyId, jcb.BoardMemberId });
            modelBuilder.Entity<JoinCompanyStockExchange>().HasKey(jcs => new { jcs.CompanyId, jcs.StockExchangeId });
        }
        public virtual DbSet<StockExchange> StockExchange { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JoinCompanyStockExchange> CompanyStockExchangePair { get; set; } //changed this name to match DB Name, need to check why Company have companies & JoinCompanyStockExchange have the same Name
        public virtual DbSet<IPODetails> IPODetails { get; set; }
        public virtual DbSet<StockPrice> StockPrice { get; set; }
    }
}
