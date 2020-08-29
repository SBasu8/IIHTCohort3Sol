using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLibraryStockChartingApp
{
    public class IPODetails
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

        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public double PricePerShare { get; set; }
        [Required]
        public int TotalShares { get; set; }
        [Required]
        public DateTime OfferingDateTime { get; set; }
        public string Remarks { get; set; }

        //Navigation reference properties
        public Company RegisteredCompany { get; set; }
        public StockExchange RegisteredStockExchange { get; set; }
    }
}
