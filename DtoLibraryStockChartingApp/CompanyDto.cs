using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DtoLibraryStockChartingApp
{
    public class CompanyDto
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

        public List<string> StockExchangeNames { get; set; }

        //Navigation reference properties
        public int SectorId { get; set; }
    }
}

