using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class AddNewCompany
    {
        private IRepository<Company> repository;

        public AddNewCompany(IRepository<Company> repository)
        {
            this.repository = repository;                
        }

        public bool InsertNewCompany()
        {
            throw new NotImplementedException();
        }
    }
}
