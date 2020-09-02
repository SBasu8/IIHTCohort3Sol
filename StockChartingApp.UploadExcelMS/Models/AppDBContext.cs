using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.UploadExcelMS.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AppDBContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinCompanyBoardMember>().HasKey(jcb => new { jcb.CompanyId, jcb.BoardMemberId });
            modelBuilder.Entity<JoinCompanyStockExchange>().HasKey(jcs => new { jcs.CompanyId, jcs.StockExchangeId });
            modelBuilder.Entity<IPODetails>().HasKey(ipo => new { ipo.RegisteredCompanyId, ipo.RegisteredStockExchangeId });
        }
        public virtual DbSet<StockPrice> StockPrice { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IPODetails> IPODetails { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
    }
}
