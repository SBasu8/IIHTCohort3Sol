using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class StockExchangeRepository
    {
        private CompanyMSContext context;

        public StockExchangeRepository(CompanyMSContext context)
        {
            this.context = context;
        }

        public bool Add(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> GetMultiple()
        {
            throw new NotImplementedException();
        }

        public StockExchange GetSingle(object key)
        {
            try
            {
                var se = context.StockExchange.Find(key);
                return se;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddCompanyRelatioship(JoinCompanyStockExchange join_cse)
        {
            try
            {
                context.JoinCompanyStockExchange.Add(join_cse);
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

        public IEnumerable<string> GetStockExchangesOfCompany(int comp_id)
        {
            var ses = context.JoinCompanyStockExchange.Where(jcse =>
            jcse.CompanyId == comp_id).Select( jcse => jcse.StockExchangeId);

            return ses;
        }

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }
    }
}
