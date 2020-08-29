using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLibraryStockChartingApp
{
    public class JoinCompanyBoardMember
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BoardMemberId { get; set; }
        public BoardMember BoardMember { get; set; }
    }
}
