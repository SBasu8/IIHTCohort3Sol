using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibraryStockChartingApp
{
    public class StockPrice
    {
        /*
        1. Company Stock Code
        2. Stock Exchange
        3. Current Price
        4. Date
        5. Time
        */

        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string StockExchangeId { get; set; }
        
        //Navigation reference properties
        public Company RegisteredCompany { get; set; }
        public StockExchange RegisteredStockExchange { get; set; }
    }
}
