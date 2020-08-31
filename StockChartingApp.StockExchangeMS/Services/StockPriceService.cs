using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class StockPriceService
    {
        private IRepository<StockPrice> repository;
        private IRepository<Company> c_repository;
        private IRepository<StockExchange> se_repository;

        public StockPriceService(IRepository<StockPrice> repository, IRepository<Company> c_repository, IRepository<StockExchange> se_repository)
        {
            this.repository = repository;
            this.c_repository = c_repository;
            this.se_repository = se_repository;
        }

        public StockPrice Get(object key)
        {
            return repository.Get(key);
        }

        public bool Add(StockPrice stockPrice)
        {
            if (c_repository.Get(stockPrice.CompanyId)!=null && se_repository.Get(stockPrice.StockExchangeId)!=null)
                return repository.Add(stockPrice);
            else return false;
        }
    }
}
