using System;
using System.ComponentModel.DataAnnotations;

namespace DtoLibraryStockChartingApp
{
    public class IPODetailsDto
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
        [Required]
        public double PricePerShare { get; set; }
        [Required]
        public int TotalShares { get; set; }
        [Required]
        public string OfferingDate { get; set; }
        [Required]
        public string OfferingTime { get; set; }
        public string Remarks { get; set; }

        //Navigation reference properties
        public int RegisteredCompanyId { get; set; }
        public string RegisteredStockExchangeId { get; set; }
    }
}
