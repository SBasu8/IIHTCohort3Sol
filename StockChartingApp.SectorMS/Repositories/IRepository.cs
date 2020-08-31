using EntityLibraryStockChartingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.SectorMS.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T entity);
       
        IEnumerable<T> GetAll();
        List<string> GetComp(int id);
        public bool UpdateCompanyList(int compid, int secid);
        
    }
}
