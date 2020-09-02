using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StockChartingApp.StockExchangeMS.Models;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockChartingApp.Tests.Unit.StockExchangeUnitTest
{
    class StockPriceRepositoryUnitTest
    {
        DbContextOptions<StockExchangeContext> options = new DbContextOptionsBuilder<StockExchangeContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        StockExchangeContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new StockExchangeContext(options);
            context.StockPrice.AddRange(GetStockPriceList());
            context.SaveChanges();
        }

        private IEnumerable<StockPrice> GetStockPriceList() 
        {
            return new List<StockPrice>()
            {
                new StockPrice(){
                    Id = 1,
                    CompanyId =1,
                    Date = "01/09/2020",
                    Time = "18:20",
                    StockExchangeId="NYSE",
                    Price = 1.03
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]

        public void Test_GetAll_ShouldReturnStockPriceList()
        {
            //Arrange
            IRepository<StockPrice> repository = new StockPriceRepository(context);

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(GetStockPriceList().Count()),
                "Comapny List does NOT match");

        }
    }
}
