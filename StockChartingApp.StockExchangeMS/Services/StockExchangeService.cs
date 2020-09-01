using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockChartingApp.StockExchangeMS.Models;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class StockExchangeService
    {
        private IRepository<StockExchange> repository;

        

        public StockExchangeService(IRepository<StockExchange> repository) { 
            this.repository = repository;
           
        }
   
        public bool Add(StockExchange entity)
        {
             return repository.Add(entity);    
        }

        public StockExchange Get(object key)
        {
            return repository.Get(key);
        }

        public IEnumerable<StockExchange> GetAll()
        {
            return repository.GetAll();
        }

    }
}
