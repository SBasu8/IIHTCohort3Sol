using System;
using System.Collections.Generic;
using System.Text;

namespace IIHTSolClassLibrary
{
    class IPO_Planned
    {
        /*
1. id
2. Company Name
3. Stock Exchange
4. Price per share
5. Total number of Shares
6. Open Date Time
7. Remarks         
         */

        public int Id { get; set; }
        public Company_Related_Data CompanyName { get; set; } // M IPODetail	: 1 Company
        public Stock_Exchange_DataFields StockExchange { get; set; } // IPO 1:1 StockExchange 
        public int PricePerShare { get; set; }
        public int TotalNo_Shares { get; set; }
        public DateTime DateTimeDetail { get; set; }
        public string Remarks { get; set; }
    }
}
