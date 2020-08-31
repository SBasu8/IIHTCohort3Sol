using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class IPODetailsService
    {
        private IPODetailsRepository repository;
        private CompanyService company_service;
        private StockExchangeService se_service;

        public IPODetailsService(IPODetailsRepository repository, CompanyService company_service, StockExchangeService se_service)
        {
            this.repository = repository;
            this.company_service = company_service;
            this.se_service = se_service;
        }

        public (bool,int) InsertNewIPODetail(int comp_id,string se_id, IPODetails ipo)
        {
            var existing_company = company_service.GetExistingCompany(comp_id);
            if(existing_company==null)
            {
                return (false,1);
            }

            var existing_stockexchange = se_service.GetExistingStockExchange(se_id);
            if(existing_stockexchange==null)
            {
                return (false,2);
            }

            ipo.RegisteredCompany = existing_company;
            ipo.RegisteredStockExchange = existing_stockexchange;

            bool add_company_se_relationship = 
                se_service.AddRelationshipWithCompany(new JoinCompanyStockExchange 
                { Company=existing_company, StockExchange=existing_stockexchange});
            if(!add_company_se_relationship)
            {
                return (false, 3);
            }

            bool added = repository.Add(ipo);
            return (added, 0);
        }

        public IPODetails GetExistingIPO(int comp_key, string se_key)
        {
            return repository.GetSingle(comp_key, se_key);
        }
    }
}
