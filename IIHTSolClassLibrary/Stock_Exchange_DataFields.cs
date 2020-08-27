using System;
using System.Collections.Generic;
using System.Text;

namespace IIHTSolClassLibrary
{
    public class Stock_Exchange_DataFields
    {
        /*
1. Id
2. Stock Exchange
3. Brief
4. Contact Address
5. Remarks
         */
        public int Id { get; set; }
        public Stock_Price_Details[] StockExchangePrice { get; set; } // 1 StockExchange : N StockPrice
        public string Brief { get; set; } // Is it Brief About ??
        public string ContactAddress { get; set; }
        public string Remarks { get; set; }

        // No Detail About Companies!!??
    }
}
