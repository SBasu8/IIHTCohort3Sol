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
        private IJoinRepository<JoinCompanyStockExchange> repository;

        public AddNewJoinCompanyStockExchangeService(IJoinRepository<JoinCompanyStockExchange> repository)
        {
            this.repository = repository;
        }
        //---------------------------------------------------------
        public JoinCompanyStockExchange Get(int key1, string key2)
        {
            return repository.Get(key1,key2);
        }

        public Tuple<bool, JoinCompanyStockExchange> Add(int c_id, string se_id)
        {
            JoinCompanyStockExchange j_c_se = new JoinCompanyStockExchange() { CompanyId = c_id, StockExchangeId = se_id };
            Tuple<bool, JoinCompanyStockExchange> t;
            t = new Tuple<bool, JoinCompanyStockExchange>(repository.Add(j_c_se), repository.Get(c_id, se_id));
            return t;
            
        }

        public bool Delete(JoinCompanyStockExchange jcse)
        {
            return repository.Delete(jcse);
        }

    }
}
