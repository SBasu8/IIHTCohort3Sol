using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLibraryStockChartingApp
{
    public class BoardMember
    {
        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Navigation collection property
        public ICollection<JoinCompanyBoardMember> JoinCompanyBod { get; set; }
    }
}
