using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class StockExchangeService
    {
        private StockExchangeRepository repository;

        public StockExchangeService(StockExchangeRepository repository)
        {
            this.repository = repository;
        }

        public StockExchange GetExistingStockExchange(string key)
        {
            return repository.GetSingle(key);
        }

        public bool AddRelationshipWithCompany(JoinCompanyStockExchange join_cse)
        {
            return repository.AddCompanyRelatioship(join_cse);
        }

        public IEnumerable<string> GetStockExchangesRegisteredWithCompany(int comp_id)
        {
            return repository.GetStockExchangesOfCompany(comp_id);
        }
    }
}
