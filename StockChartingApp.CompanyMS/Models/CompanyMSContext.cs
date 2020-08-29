using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityLibraryStockChartingApp;
using System.Diagnostics.CodeAnalysis;

namespace StockChartingApp.CompanyMS.Models
{
    public class CompanyMSContext : DbContext
    {
        public CompanyMSContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public CompanyMSContext()
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinCompanyBoardMember>().HasKey(jcb => new { jcb.CompanyId, jcb.BoardMemberId });
            modelBuilder.Entity<JoinCompanyStockExchange>().HasKey(jcs => new { jcs.CompanyId, jcs.StockExchangeId });
        }

        public DbSet<Company> Companies { get; set; }
    }
}
