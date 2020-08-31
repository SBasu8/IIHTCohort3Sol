using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class AddNewStockPriceService
    {
        private IRepository<StockPrice> repository;

        public AddNewStockPriceService(IRepository<StockPrice> repository)
        {
            this.repository = repository;
        }

        public StockPrice Get(object key)
        {
            return repository.Get(key);
        }

        public bool Add(StockPrice stockPrice)
        {
            stockPrice.
            return repository.Add(stockPrice);
        }
    }
}
