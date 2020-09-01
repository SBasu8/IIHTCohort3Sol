using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class StockExchangeRepository : IRepository<StockExchange>
    {
        StockExchangeContext context;
        public StockExchangeRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        //-----------------------------------------------------------
        public bool Add(StockExchange entity)
        {
            //throw new NotImplementedException();
            try
            {
                //bool check = context.Database.CanConnect();

                // Mapping to be Done in Repository
                List<JoinCompanyStockExchange> jpar = new List<JoinCompanyStockExchange>();
                List<IPODetails> ipopar = new List<IPODetails>();
                List<StockPrice> sppar = new List<StockPrice>();


                entity.JoinCompanyExchanges = jpar;
                entity.Ipos = ipopar;
                entity.CurrentPrices = sppar;

                context.StockExchange.Add(entity);
                int u = context.SaveChanges();
                if ( u > 0) return true;
                else return false;
            }
            catch (Exception) {return false; }

        }

        public bool Delete(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public StockExchange Get(object key)
        {
            return context.StockExchange.Find(key);
        }

        public IEnumerable<StockExchange> GetAll()
        {
            return context.StockExchange;
        }

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }
    }
}
