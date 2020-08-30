using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using StockChartingApp.SectorMS.Models;

namespace StockChartingApp.SectorMS.Repositories
{
    public class SectorRepository : IRepository<Sector>
    {
        SectorMSContext context;
        public SectorRepository(SectorMSContext context)
        {
            this.context = context;
            
        }

        public bool Add(Sector entity)
        {
            //throw new NotImplementedException();
            try
            {
                bool check = context.Database.CanConnect();
                context.Sector.Add(entity);
                int u = context.SaveChanges();
                if (u > 0) return true;
                else return false;
            }
            catch (Exception) { return false; }

        }

        public string Get(string sectorName)
        {

            /*var ans = context.Sector
                   .Where(s => s.SectorName == sectorName).Select(b => b.Companies.Select(p => p.CompanyName))
                   .FirstOrDefault();*/

            var ans = context.Sector
                   .Where(s => s.SectorName == sectorName).Select(b => b.About)
                   .FirstOrDefault();

            return ans ;
            //return context.Sector.Find(key);
            //throw new NotImplementedException();
        }

        public IEnumerable<Sector> GetAll()
        {
            return context.Sector;
            //throw new NotImplementedException();
        }
    }
}
