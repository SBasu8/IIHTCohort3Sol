﻿using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private StockExchangeContext context;

        public CompanyRepository(StockExchangeContext context)
        {
            this.context = context;
        }

        public bool Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public Company Get(object key)
        {
            //throw new NotImplementedException();
            return context.Companies.FirstOrDefault(c => c.Id == Convert.ToInt32(key));
        }

        public IEnumerable<Company> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
