using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class JoinCompanyStockExchangeService
    {
        private IJoinRepository<JoinCompanyStockExchange> repository;

        public JoinCompanyStockExchangeService(IJoinRepository<JoinCompanyStockExchange> repository)
        {
            this.repository = repository;
        }
        //---------------------------------------------------------
        public JoinCompanyStockExchange Get(int key1, string key2)
        {
            return repository.Get(key1,key2);
        }

        public bool Add(JoinCompanyStockExchange joinCompanyStockExchange)
        {
            return repository.Add(joinCompanyStockExchange);
            
        }

        public bool Delete(JoinCompanyStockExchange jcse)
        {
            return repository.Delete(jcse);
        }

    }
}
