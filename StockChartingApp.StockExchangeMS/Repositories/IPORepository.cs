using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class IPORepository : IRepository<IPODetails>
    {
        private StockExchangeContext context;

        public IPORepository(StockExchangeContext context)
        {
            this.context = context;
        }
        //----------------------------------------------------------
        public bool Add(IPODetails entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IPODetails entity)
        {
            throw new NotImplementedException();
        }

        public IPODetails Get(object key)
        {
            return context.IPODetails.Find(key);
        }

        public IEnumerable<IPODetails> GetAll()
        {
            return context.IPODetails;
        }

        public bool Update(IPODetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
