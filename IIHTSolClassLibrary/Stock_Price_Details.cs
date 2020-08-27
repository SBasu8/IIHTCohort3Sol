using System;
using System.Collections.Generic;
using System.Text;

namespace IIHTSolClassLibrary
{
    class Stock_Price_Details
    {
        /*
1. Company Code – to which Company this Stock Price Info belongs to
2. Stock Exchange – the Stock Price of the Company in this Stock Exchange 
3. Current Price – Stock Price
4. Date – Date of the Stock Price
5. Time – Stock Price at this Specific time
        */
        public Company_Related_Data CompanyCode { get; set; } //1 Company : N StockPrice
        public Stock_Exchange_DataFields StockExchangePrice { get; set; } // 1 StockExchange : N StockPrice
        public int StockCurrentPrice { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        
    }
}
