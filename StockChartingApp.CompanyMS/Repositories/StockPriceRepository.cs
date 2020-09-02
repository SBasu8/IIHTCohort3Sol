using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class StockPriceRepository
    {
        private CompanyMSContext context;

        public StockPriceRepository(CompanyMSContext context)
        {
            this.context = context;
        }

        public IEnumerable<StockPrice> GetMultiple(int comp_id, string se_id, DateTime From, DateTime To)
        {
            var stock_prices = from sp in context.StockPrice
                               where sp.CompanyId == comp_id &&
                               sp.StockExchangeId == se_id &&
                               sp.DateTime >= From &&
                               sp.DateTime <= To
                               select sp;
            return stock_prices;
        }
    }
}
