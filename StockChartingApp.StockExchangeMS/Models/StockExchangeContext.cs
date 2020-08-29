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

        public virtual DbSet<StockExchange> StockExchange { get; set; }
    }
}
