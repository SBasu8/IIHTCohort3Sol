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
        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IPODetails> IPODetails { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
    }
}
