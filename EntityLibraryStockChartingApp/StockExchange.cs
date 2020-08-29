using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibraryStockChartingApp
{
    public class StockExchange
    {
        /*
        1. Id
        2. Stock Exchange
        3. Brief
        4. Contact Address
        5. Remarks
        */

        //Value properties
        [Key]
        public string Id { get; set; }
        [Required]
        public string ExchangeName { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Address { get; set; }
        public string Remarks { get; set; }

        //Navigation collection properties
        public ICollection<JoinCompanyStockExchange> JoinCompanyExchanges { get; set; }
        public ICollection<StockPrice> CurrentPrices { get; set; }
        public ICollection<IPODetails> Ipos { get; set; }
    }
}
