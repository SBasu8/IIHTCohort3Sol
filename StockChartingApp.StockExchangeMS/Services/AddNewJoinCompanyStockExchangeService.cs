using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class AddNewJoinCompanyStockExchangeService
    {
        private IRepository<JoinCompanyStockExchange> repository;

        public AddNewJoinCompanyStockExchangeService(IRepository<JoinCompanyStockExchange> repository)
        {
            this.repository = repository;
        }

        public JoinCompanyStockExchange Get(int key1, string key2)
        {
            List<string> k = new List<string>(); k.Add(Convert.ToString(key1));k.Add(key2);
            return repository.Get(k);
        }
    }
}
