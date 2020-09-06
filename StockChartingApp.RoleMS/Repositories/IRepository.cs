using DtoLibraryStockChartingApp;
using EntityLibraryStockChartingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.RoleMS.Repositories
{
    public interface IRepository<T>
    {
        bool Signup(T entity);
        Tuple<bool, TokenDetails> AdminLogin(string uname, string pass);
        Tuple<bool, TokenDetails> UserLogin(string uname, string pass);
        bool Logout();
    }
}
