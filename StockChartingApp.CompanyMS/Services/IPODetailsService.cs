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
                OfferingDateTime = Convert.ToDateTime(ipo_dto.OfferingDate + " " + ipo_dto.OfferingTime),
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

        public IPODetailsDto GetExistingIPO(int comp_key, string se_key)
        {
            IPODetails ipo = repository.GetSingle(comp_key, se_key);
            return new IPODetailsDto
            {
                PricePerShare = ipo.PricePerShare,
                TotalShares = ipo.TotalShares,
                OfferingDate = ipo.OfferingDateTime.ToShortDateString(),
                OfferingTime = ipo.OfferingDateTime.ToShortTimeString(),
                Remarks = ipo.Remarks,
                RegisteredCompanyId = ipo.RegisteredCompanyId,
                RegisteredStockExchangeId = ipo.RegisteredStockExchangeId
            };
        }

        public IEnumerable<IPODetailsDto> GetAllExistingIPOs()
        {
            List<IPODetailsDto> ipo_dto_list = new List<IPODetailsDto>();

            foreach(IPODetails ipo in repository.GetMultiple())
            {
                ipo_dto_list.Add(new IPODetailsDto
                {
                    PricePerShare = ipo.PricePerShare,
                    TotalShares = ipo.TotalShares,
                    OfferingDate = ipo.OfferingDateTime.ToShortDateString(),
                    OfferingTime = ipo.OfferingDateTime.ToShortTimeString(),
                    Remarks = ipo.Remarks,
                    RegisteredCompanyId = ipo.RegisteredCompanyId,
                    RegisteredStockExchangeId = ipo.RegisteredStockExchangeId
                });
            }
            return ipo_dto_list;
        }
    }
}
