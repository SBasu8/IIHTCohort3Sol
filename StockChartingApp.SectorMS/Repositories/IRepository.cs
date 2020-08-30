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
       // bool Update(T entity);
       // bool Delete(T entity);
        IEnumerable<T> GetAll();
        string Get(string sectorName);
    }
}
