using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityLibraryStockChartingApp;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;


namespace StockChartingApp.SectorMS.Models
{
    public class SectorMSContext : DbContext
    {
        public SectorMSContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            
        }

        protected SectorMSContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinCompanyBoardMember>().HasKey(jcb => new { jcb.CompanyId, jcb.BoardMemberId });
            modelBuilder.Entity<JoinCompanyStockExchange>().HasKey(jcs => new { jcs.CompanyId, jcs.StockExchangeId });
            modelBuilder.Entity<IPODetails>()
           .HasKey(ipo => new { ipo.RegisteredCompanyId, ipo.RegisteredStockExchangeId });

        }
       

        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<Company> Company { get; set; }
    }
}
