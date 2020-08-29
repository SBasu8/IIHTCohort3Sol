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

        protected StockExchangeContext()
        {
        }
        //Important for many many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinCompanyBoardMember>().HasKey(jcb => new { jcb.CompanyId, jcb.BoardMemberId });
            modelBuilder.Entity<JoinCompanyStockExchange>().HasKey(jcs => new { jcs.CompanyId, jcs.StockExchangeId });
        }
        public virtual DbSet<StockExchange> StockExchange { get; set; }
    }
}
