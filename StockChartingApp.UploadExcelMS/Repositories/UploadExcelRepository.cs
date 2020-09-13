using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using StockChartingApp.UploadExcelMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.UploadExcelMS.Repositories
{
    public class UploadExcelRepository : IUploadExcelRepository<AppDBContext>
    {
        private AppDBContext context;

        public UploadExcelRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void UploadExcel(IFormFile file)
        {
            var list = new List<StockPrice>();
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var pkg = new ExcelPackage(stream))
                {
                    ExcelWorksheet ew = pkg.Workbook.Worksheets[0];
                    var rCount = ew.Dimension.Rows;

                    for (int row = 2; row <= rCount; row++)
                    {
                        string dtToParse = ew.Cells[row, 4].Value.ToString().Split(' ')[0] + " " + ew.Cells[row, 5].Value.ToString().Trim();
                        if (dtToParse == " ") break;
                        list.Add(
                                  new StockPrice()
                                  {
                                      CompanyId = int.Parse(ew.Cells[row, 1].Value.ToString().Trim()),
                                      StockExchangeId = ew.Cells[row, 2].Value.ToString().Trim(),
                                      Price = Convert.ToDouble(ew.Cells[row, 3].Value.ToString().Trim()),
                                      DateTime = DateTime.ParseExact(dtToParse, "dd-MM-yyyy HH:mm:ss", null)
                                  }
                              );
                    }
                    context.StockPrice.AddRange(list);
                    context.SaveChanges();
                }
            }
        }
    }
}
