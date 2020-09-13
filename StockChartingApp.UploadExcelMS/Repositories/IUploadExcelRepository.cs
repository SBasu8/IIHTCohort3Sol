using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.UploadExcelMS.Repositories
{
    public interface IUploadExcelRepository<T>
    {
        void UploadExcel(IFormFile file);
    }
}
