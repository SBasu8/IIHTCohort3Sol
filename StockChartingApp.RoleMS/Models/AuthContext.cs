using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.RoleMS.Models
{
    public class AuthContext : DbContext
    {
        public AuthContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AuthContext()
        {
        }

        public virtual DbSet<Role> Role { get; set; }
    }
}
