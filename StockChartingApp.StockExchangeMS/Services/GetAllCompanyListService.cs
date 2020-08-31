using EntityLibraryStockChartingApp;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Services
{
    public class GetAllCompanyListService
    {
        private IJoinRepository<JoinCompanyStockExchange> repository;
        private IRepository<Company> crepository;

        public GetAllCompanyListService(IJoinRepository<JoinCompanyStockExchange> repository, IRepository<Company> crepository)
        {
            this.repository = repository;
            this.crepository = crepository;
        }

        public IEnumerable<Company> GetAllCompaniesList(string Id)
        {
            var pairList = repository.GetAll(); //.Where(pair => pair.StockExchangeId == Convert.ToString(key));
                     
            List<Company> companyList = new List<Company>();
            foreach (var p in pairList)
            {
                Console.WriteLine(p);
                if(p.StockExchangeId == Id )
                companyList.Add(crepository.Get(p.CompanyId));
            }
            return companyList;
        }
    }
}
