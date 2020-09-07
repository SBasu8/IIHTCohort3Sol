using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DtoLibraryStockChartingApp
{
    public class SectorDto
    {
            /*1. Id
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
    }
}
