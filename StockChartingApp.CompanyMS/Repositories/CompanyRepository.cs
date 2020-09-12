using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using StockChartingApp.CompanyMS.Models;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class CompanyRepository
    {
        private CompanyMSContext context;

        public CompanyRepository(CompanyMSContext context)
        {
            this.context = context;
        }

        public bool Add(Company entity)
        {
            try
            {
                context.Company.Add(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            try
            {
                context.Company.Remove(entity);
                var updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Company GetSingle(object key)
        {
            try
            {
                var company = context.Company.Find(key);
                return company;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public IEnumerable<Company> GetMultiple()
        {
            return context.Company.ToList();
        }

        public IEnumerable<string> MatchingCompanies(string partial)
        {
            var name_list = context.Company.AsNoTracking()
                .Where(c => c.CompanyName.Contains(partial))
                .Select(c => c.CompanyName);
            return name_list;
        }

        public bool Update(Company existing,Company entity)
        {
            try
            {
                context.Entry(existing).CurrentValues.SetValues(entity);
                var updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }      
    }
}
