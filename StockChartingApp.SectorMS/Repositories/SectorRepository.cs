﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using StockChartingApp.SectorMS.Models;
using Microsoft.Extensions.DependencyInjection;

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
                entity.Companies = new List<Company>();
                context.Sector.Add(entity);
                int u = context.SaveChanges();
                if (u > 0) return true;
                else return false;
            }
            catch (Exception) { return false; }

        }

        public List<string> GetComp(int id)
        {

            var ans_ = context.Sector
                   .Where(s => s.Id == id).Select(p => p.Companies).FirstOrDefault();
                   
            List<string> strlst_ = new List<string>();
            foreach (var c in ans_) {
                strlst_.Add(c.CompanyName);
            }
            return strlst_;

            /*var ans = context.Sector
                   .Where(s => s.Id == id)
                   .FirstOrDefault();

            return ans.About ;*/
            //return context.Sector.Find(key);
            //throw new NotImplementedException();
        }
       
        public bool UpdateCompanyList(int CompId,int SecId)
        {
            
            var compi_ = context.Company.Where(s => s.Id == SecId).FirstOrDefault();
            var sec_ = context.Sector.Where(s => s.Id == SecId).FirstOrDefault();
            if (sec_.Companies == null) {
                sec_.Companies = new List<Company>();
            }
            sec_.Companies.Add(compi_);
            
            context.SaveChanges();
            return true;
        }
        public IEnumerable<Sector> GetAll()
        {
            return context.Sector;
            //throw new NotImplementedException();
        }
    }
}
