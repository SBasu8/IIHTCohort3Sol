using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.RoleMS.Repositories
{
    public interface IRepository<T>
    {
        bool Signup(T entity);
        Tuple<bool, string> Login(string uname, string pass);
        bool Logout();
    }
}
