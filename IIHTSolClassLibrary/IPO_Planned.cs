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
        public string CompanyName { get; set; }
        public int StockExchange { get; set; }
        public int PricePerShare { get; set; }
        public int TotalNo_Shares { get; set; }
        public DateTime DateTimeDetail { get; set; }
        public string Remarks { get; set; }
    }
}
