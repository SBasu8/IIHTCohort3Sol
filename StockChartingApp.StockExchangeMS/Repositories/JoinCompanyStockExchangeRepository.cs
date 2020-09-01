using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class JoinCompanyStockExchangeRepository : IJoinRepository<JoinCompanyStockExchange>
    {
        private StockExchangeContext context;

        public JoinCompanyStockExchangeRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        //--------------------------------------------------------------------
        public bool Add(JoinCompanyStockExchange entity)
        {
            //try
            //{
            //    context.JoinCompanyStockExchange.Add(entity);
            //    int u = context.SaveChanges();
            //    if (u > 0) return true;   else return false;
            //}
            //catch (Exception) { return false; }
            throw new NotImplementedException();
        }

        public bool Delete(JoinCompanyStockExchange entity)
        {
            try {
                context.JoinCompanyStockExchange.Remove(entity);
                var u = context.SaveChanges();
                if (u > 0) return true; else return false;
            }
            catch (Exception){ return false; }
        }


        public JoinCompanyStockExchange Get(object key1, object key2)
        {

            return context.JoinCompanyStockExchange.Find(Convert.ToInt32(key1), key2);

        }

        public IEnumerable<JoinCompanyStockExchange> GetAll()
        {
            return context.JoinCompanyStockExchange;
        }
    }
}
