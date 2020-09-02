using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DtoLibraryStockChartingApp
{
    public class StockPriceDto
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string StockExchangeId { get; set; }
    }
}
