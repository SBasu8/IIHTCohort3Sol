using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLibraryStockChartingApp
{
    public class JoinCompanyStockExchange
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int StockExchangeId { get; set; }
        public StockExchange StockExchange { get; set; }
    }
}
