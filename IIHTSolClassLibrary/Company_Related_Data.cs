namespace IIHTSolClassLibrary
{
    public class Company_Related_Data
    {
        /*
1. Company Name
2. Turnover
3. CEO
4. Board of Directors
5. Listed in Stock Exchanges
6. Sector
7. Brief writeup, about companies Services/Product, etc…
8. Stock code in each Stock Exchange
        */

        public string CompanyName { get; set; }
        public string Turnover { get; set; } //Dont know exactly what it is
        public string CEO { get; set; }
        public string[] Board_Directores { get; set; }
        public Stock_Exchange_DataFields[] StockExchange { get; set; } //M StockExchanges : N Companies
        public string Sector { get; set; }
        public string BriefAbout { get; set; }
        public int[] StockCode { get; set; }

        //No IPO Deatils!!??

        // No StockPriceDetails!!??
    }
}
