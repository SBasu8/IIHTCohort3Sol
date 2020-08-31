using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class AddNewIPOService
    {
        private IRepository<IPODetails> repository;

        public AddNewIPOService(IRepository<IPODetails> repository)
        {
            this.repository = repository;
        }

        public IPODetails Get(object key)
        {
            return repository.Get(key);
        }
    }
}
