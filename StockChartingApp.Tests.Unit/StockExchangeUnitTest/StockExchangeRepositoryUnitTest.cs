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
    class StockExchangeRepositoryUnitTest
    {
        DbContextOptions<StockExchangeContext> options = new DbContextOptionsBuilder<StockExchangeContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        StockExchangeContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new StockExchangeContext(options);
            context.StockExchange.AddRange(GetStockExchangeList());
            context.SaveChanges();
        }

        private IEnumerable<StockExchange> GetStockExchangeList() 
        {
            return new List<StockExchange>()
            {
                new StockExchange(){
                    Id="NYSE",
                    ExchangeName = "New York Stock Exchange",
                    About="New York's Stock Exchange",
                    Address="New York",
                    Remarks = "Amazing",
                    CurrentPrices = new List<StockPrice>(),
                    Ipos = new List<IPODetails>(),
                    JoinCompanyExchanges = new List<JoinCompanyStockExchange>()

                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]

        public void Test_GetAll_ShouldReturnStockExchangeList()
        {
            //Arrange
            IRepository<StockExchange> repository = new StockExchangeRepository(context);

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(GetStockExchangeList().Count()),
                "Comapny List does NOT match");

        }
    }
}
