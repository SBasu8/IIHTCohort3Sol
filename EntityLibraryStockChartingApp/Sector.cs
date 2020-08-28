using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLibraryStockChartingApp
{
    public class Sector
    {
        /*
        1. Id
        2. Sector Name
        3. Brief
        */

        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string SectorName { get; set; }
        [Required]
        public string About { get; set; }

        //Navigation collection properties
        public ICollection<Company> Companies { get; set; }
    }
}
