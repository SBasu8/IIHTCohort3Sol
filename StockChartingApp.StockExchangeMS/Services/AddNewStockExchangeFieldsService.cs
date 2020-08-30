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
            /* 
             * Not yet Still working on this
             * --------
            JoinCompanyStockExchange j = new JoinCompanyStockExchange()
            {
                Company = new Company(),
                CompanyId = 1,
                StockExchange = entity,
                StockExchangeId = Convert.ToInt32(entity.Id)   // this is for the time being as discr
            };
            entity.JoinCompanyExchanges = new List<JoinCompanyStockExchange>();
            entity.Ipos = new List<IPODetails>();
            entity.CurrentPrices = new List<StockPrice>();
            -----------
            */
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
