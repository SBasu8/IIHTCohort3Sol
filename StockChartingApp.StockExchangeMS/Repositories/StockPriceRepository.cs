﻿using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public class StockPriceRepository : IRepository<StockPrice>
    {
        private StockExchangeContext context;

        public StockPriceRepository(StockExchangeContext context)
        {
            this.context = context;
        }

        public bool Add(StockPrice entity)
        {
            throw new NotImplementedException();
        }

        public StockPrice Get(object key)
        {
            return context.StockPrice.Find(key);
        }

        public IEnumerable<StockPrice> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
