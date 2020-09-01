using DtoLibraryStockChartingApp;
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

        public (bool,int) InsertNewIPODetail(IPODetailsDto ipo_dto)
        {
            var existing_company = company_service.GetExistingCompany(ipo_dto.RegisteredCompanyId);
            if(existing_company==null)
            {
                return (false,1);
            }

            var existing_stockexchange = se_service.GetExistingStockExchange(ipo_dto.RegisteredStockExchangeId);
            if(existing_stockexchange==null)
            {
                return (false,2);
            }

            var ipo = new IPODetails
            {
                PricePerShare = ipo_dto.PricePerShare,
                TotalShares = ipo_dto.TotalShares,
                OfferingDateTime = ipo_dto.OfferingDateTime,
                Remarks = ipo_dto.Remarks,
                RegisteredCompany = existing_company,
                RegisteredStockExchange = existing_stockexchange
            };

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
