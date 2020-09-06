using DtoLibraryStockChartingApp;
using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class CompanyService
    {
        private CompanyRepository repository;
        private StockExchangeService se_service;

        public CompanyService(CompanyRepository repository, StockExchangeService se_service)
        {
            this.repository = repository;
            this.se_service = se_service;
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
            return repository.GetSingle(key);
        }

        public IEnumerable<CompanyDto> GetAllCompanies()
        {
            List<CompanyDto> AllCompanyList = new List<CompanyDto>();
            foreach(Company comp in repository.GetMultiple())
            {
                AllCompanyList.Add(
                    new CompanyDto
                    {
                        Id = comp.Id,
                        CompanyName = comp.CompanyName,
                        Turnover = comp.Turnover,
                        Ceo = comp.Ceo,
                        About = comp.About,
                        StockExchangeNames = 
                        se_service.GetStockExchangesRegisteredWithCompany(comp.Id).ToList(),
                        SectorId = comp.SectorId
                    }
                    );
            }

            return AllCompanyList;
        }

        public (bool,int) UpdateCompanyDetails(Company company)
        {
            var existing = repository.GetSingle(company.Id);
            if(existing == null)
            {
                return (false,1);
            }

            var updated = repository.Update(existing, company);
            if(updated)
            {
                return (true,1);
            }

            return (false,2);
        }

        public (bool,int) DeleteCompany(int key)
        {
            var existsing = repository.GetSingle(key);
            if(existsing==null)
            {
                return (false,1);
            }

            var deleted = repository.Delete(existsing);
            if(deleted)
            {
                return (true, 1);
            }

            return (false, 2);
        }

        public IEnumerable<string> FetchMatchingCompanies(string partial)
        {
            return repository.MatchingCompanies(partial);
        }
    }
}
