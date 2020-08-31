using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.StockExchangeMS.Repositories
{
    public interface IJoinRepository<T>
    {
        //Create & Delete only

        bool Add(T entity);
        bool Delete(T entity);
        T Get(object key1, object key2);
        IEnumerable<T> GetAll();
        
    }
}
