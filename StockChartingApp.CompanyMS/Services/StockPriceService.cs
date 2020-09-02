using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtoLibraryStockChartingApp;
using EntityLibraryStockChartingApp;

namespace StockChartingApp.CompanyMS.Services
{
    public class StockPriceService
    {
        private StockPriceRepository repository;

        public StockPriceService(StockPriceRepository repository)
        {
            this.repository = repository;
        }

        private TimeSpan GetPeriod(int periodicity)
        {
            switch(periodicity)
            {
                case 1: //One Day data
                    return new TimeSpan(0, 30, 0);
                case 2: //One Month data
                    return new TimeSpan(24, 0, 0);
                case 3: //One Year data
                    return new TimeSpan(720, 0, 0);
                default:
                    return new TimeSpan(0, 30, 0);
            }
        }

        public IEnumerable<StockPriceDto> FetchComapnyStockPrices(StockPriceRequestDto spq)
        {
            var stock_prices = repository.GetMultiple
                (spq.CompanyId,spq.StockExchangeId,Convert.ToDateTime(spq.From),Convert.ToDateTime(spq.To));
            var stock_price_dtos = new List<StockPriceDto>();
            DateTime till_date = Convert.ToDateTime(spq.From);
            foreach(StockPrice sp in stock_prices)
            {
                if(sp.DateTime >= till_date)
                {
                    stock_price_dtos.Add(
                        new StockPriceDto
                        {
                            Price = sp.Price,
                            Date = sp.DateTime.ToShortDateString(),
                            Time = sp.DateTime.ToShortTimeString(),
                            CompanyId = sp.CompanyId,
                            StockExchangeId = sp.StockExchangeId
                        });
                    till_date += GetPeriod(spq.Periodicity);
                }
            }
            return stock_price_dtos;
        }
    }
}
