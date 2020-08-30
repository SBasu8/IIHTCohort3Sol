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

        public bool Add(StockExchange entity)
        {
            //throw new NotImplementedException();
            try
            {
                //bool check = context.Database.CanConnect();
                context.StockExchange.Add(entity);
                int u = context.SaveChanges();
                if ( u > 0) return true;
                else return false;
            }
            catch (Exception) {return false; }

        }

        public StockExchange Get(object key)
        {
            return context.StockExchange.Find(key);
            //throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> GetAll()
        {
            return context.StockExchange;
            //throw new NotImplementedException();
        }


    }
}
