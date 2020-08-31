using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockChartingApp.StockExchangeMS.Models;
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
        private AddNewCompanyService ac;
        private AddNewStockPriceService asp;
        private AddNewJoinCompanyStockExchangeService ajcse;
        private AddNewIPOService aipo;

        public AddNewStockExchangeFieldsService(IRepository<StockExchange> repository,AddNewCompanyService ac, AddNewStockPriceService asp, AddNewJoinCompanyStockExchangeService ajcse, AddNewIPOService aipo) 
        {
            this.repository = repository;
            this.ac = ac;
            this.asp = asp;
            this.ajcse = ajcse;
            this.aipo = aipo;
        }
   
        public bool Add(StockExchange entity)
        {
            Company cmp = ac.Get(6);
            List<JoinCompanyStockExchange> jpar = new List<JoinCompanyStockExchange>();
            List<IPODetails> ipopar = new List<IPODetails>();
            List<StockPrice> sppar = new List<StockPrice>();

            /*
           
            jpar.Add(j);

            IPODetails ipo = new IPODetails()
            {
                //Id = 1,
                PricePerShare = 0.98,
                TotalShares = 1000,
                OfferingDateTime = new DateTime(),
                Remarks = "Amazing",
                RegisteredCompany = cmp,
                RegisteredStockExchange = entity

            };
            ipopar.Add(ipo);

            

            */
            //Implementing get for above 3

            JoinCompanyStockExchange j = new JoinCompanyStockExchange()
            {
                Company = cmp,
                CompanyId = cmp.Id,
                StockExchange = entity,
                StockExchangeId = entity.Id
            };
            jpar.Add(j);
            ipopar.Add(aipo.Get(3));
            StockPrice sp = new StockPrice()
            {
                //Id = 1,
                CompanyId = 6,
                Price = 0.98,
                Date = "10/10/2010",
                Time = "0930",
                StockExchangeId = entity.Id,
                RegisteredCompany = ac.Get(6),
                RegisteredStockExchange = entity,
            };
            sppar.Add(sp);


            //THE ABOVE FEELS A BIT HARD CODED. NEED TO FIND BETTER SOLUTION

            entity.JoinCompanyExchanges = jpar;
            entity.Ipos = ipopar;
            entity.CurrentPrices = sppar;

            return repository.Add(entity);
            
        }

        public StockExchange Get(object key)
        {
            return repository.Get(key);
        }

        public IEnumerable<StockExchange> GetAll()
        {
            return repository.GetAll();
        }

    }
}
