using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Models;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class CompanyRepository : repository<Company>
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
                bool conn = context.Database.CanConnect();

                context.Companies.Add(entity);
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
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Get()
        {
            throw new NotImplementedException();
        }

        public Company Get(object key)
        {
            var company = context.Companies.Find(key);
            return company;
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
