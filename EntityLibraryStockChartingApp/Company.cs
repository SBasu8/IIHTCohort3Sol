using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLibraryStockChartingApp
{
    public class Company
    {
        /*
        1. Company Name
        2. Turnover
        3. CEO
        4. Board of Directors
        5. Listed in Stock Exchanges
        6. Sector
        7. Brief writeup, about companies Services/Product, etc…
        8. Company stock code with each Stock Exchange
        */

        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public double Turnover { get; set; }
        [Required]
        public string Ceo { get; set; }
        [Required]
        public string About { get; set; }

        //Navigation reference properties
        public Sector BusinessSector { get; set; }

        //Navigation collection properties
        public ICollection<JoinCompanyBoardMember> JoinCompanyBod { get; set; }
        public ICollection<JoinCompanyStockExchange> JoinCompanyExchanges { get; set; }
        public ICollection<StockPrice> CurrentPrices { get; set; }
        public ICollection<IPODetails> Ipos { get; set; }
    }
}
