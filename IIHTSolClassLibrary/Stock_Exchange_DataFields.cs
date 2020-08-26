using System;
using System.Collections.Generic;
using System.Text;

namespace IIHTSolClassLibrary
{
    class Stock_Exchange_DataFields
    {
        /*
1. Id
2. Stock Exchange
3. Brief
4. Contact Address
5. Remarks
         */
        public int Id { get; set; }
        public int StockExchangePrice { get; set; }
        public string Brief { get; set; } // Is it Brief About ??
        public string ContactAddress { get; set; }
        public string Remarks { get; set; }
    }
}
