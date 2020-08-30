using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.DataProtection.Repositories;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class AddNewStockExchangeFieldsService
    {
        private IRepository<StockExchange> repository;

        public AddNewStockExchangeFieldsService(IRepository<StockExchange> repository) 
        {
            this.repository = repository;
        }

        public bool Add(StockExchange entity)
        {
            //throw new NotImplementedException();
            List<JoinCompanyStockExchange> jpar = new List<JoinCompanyStockExchange>();
            //JoinCompanyStockExchange j = new JoinCompanyStockExchange()
            //{
            //    Company = new Company(),
            //    CompanyId = 1,
            //    StockExchange = entity,
            //    StockExchangeId = entity.Id   
            //};
            //jpar.Add(j);

            List<IPODetails> ipopar = new List<IPODetails>();
            //IPODetails ipo = new IPODetails()
            //{
            //    Id = 1, PricePerShare = 0.9, TotalShares = 1000, OfferingDateTime = new DateTime(),
            //    Remarks = "Amazing", RegisteredCompany = j.Company,RegisteredStockExchange = entity

            //};
            //ipopar.Add(ipo);

            List<StockPrice> sppar = new List<StockPrice>();
            //StockPrice sp = new StockPrice()
            //{
            //    Id=1,
            //    CompanyId=1, 
            //    Price = 0.98, 
            //    Date ="10/10/2010", 
            //    Time = "0930",
            //    StockExchangeId=entity.Id,
            //    RegisteredCompany = j.Company, 
            //    RegisteredStockExchange = entity
            //};
            //sppar.Add(sp);

            entity.JoinCompanyExchanges = jpar;
            entity.Ipos = ipopar;
            entity.CurrentPrices = sppar;
           
            return repository.Add(entity);

        }

        public StockExchange Get(object key)
        {
            return repository.Get(key);
            //throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> GetAll()
        {
            return repository.GetAll();
            //throw new NotImplementedException();
        }

    }
}
