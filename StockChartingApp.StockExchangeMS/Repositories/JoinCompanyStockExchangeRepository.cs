using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class JoinCompanyStockExchangeRepository : IRepository<JoinCompanyStockExchange>
    {
        private StockExchangeContext context;

        public JoinCompanyStockExchangeRepository(StockExchangeContext context)
        {
            this.context = context;
        }

        public bool Add(JoinCompanyStockExchange entity)
        {
            throw new NotImplementedException();
        }

        public JoinCompanyStockExchange Get(object key)
        {
            List<string> kl = new List<string>();
            foreach (var k in (dynamic)key) { kl.Add(k); }
            return context.CompanyStockExchangePair.Find(Convert.ToInt32(kl[0]),kl[1]);
        }

        public IEnumerable<JoinCompanyStockExchange> GetAll()
        {
            return context.CompanyStockExchangePair;
           
        }
    }
}
