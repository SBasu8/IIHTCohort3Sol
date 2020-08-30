using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityLibraryStockChartingApp;
using System.Diagnostics.CodeAnalysis;


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
            /*modelBuilder.Entity<Sector>()
                    .HasMany<Company>(g => g.Companies)
                    .WithOne(s => s.BusinessSector)
                    .HasForeignKey(s => s.BusinessSector);*/

        }
       

        public virtual DbSet<Sector> Sector { get; set; }
    }
}
