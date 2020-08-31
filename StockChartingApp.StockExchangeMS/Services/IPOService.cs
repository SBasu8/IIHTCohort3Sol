using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class IPOService
    {
        private IRepository<IPODetails> repository;

        public IPOService(IRepository<IPODetails> repository)
        {
            this.repository = repository;
        }

        public IPODetails Get(object key)
        {
            return repository.Get(key);
        }
    }
}
