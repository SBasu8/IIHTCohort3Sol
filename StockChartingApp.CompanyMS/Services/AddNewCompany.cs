using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class AddNewCompany
    {
        private repository<Company> repository;

        public AddNewCompany(repository<Company> repository)
        {
            this.repository = repository;                
        }

        public bool InsertNewCompany(Company company)
        {
            company.JoinCompanyBod = new List<JoinCompanyBoardMember>();
            company.JoinCompanyExchanges = new List<JoinCompanyStockExchange>();
            company.Ipos = new List<IPODetails>();
            company.CurrentPrices = new List<StockPrice>();
            return repository.Add(company);
        }

        public Company GetExistingCompany(int key)
        {
            return repository.Get(key);
        }
    }
}
