using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DtoLibraryStockChartingApp
{
    public class StockPriceRequestDto
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public int Periodicity { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string StockExchangeId { get; set; }
    }
}
