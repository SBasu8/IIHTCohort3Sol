using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Models;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class IPODetailsRepository
    {
        private CompanyMSContext context;

        public IPODetailsRepository(CompanyMSContext context)
        {
            this.context = context;
        }
        public bool Add(IPODetails entity)
        {
            try
            {
                context.IPODetails.Add(entity);
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

        public bool Delete(IPODetails entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(IPODetails entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPODetails> GetMultiple()
        {
            return context.IPODetails;
        }

        public IPODetails GetSingle(int comp_key, string se_key)
        {
            try
            {
                var ipo = context.IPODetails.Find(comp_key,se_key);
                return ipo;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
