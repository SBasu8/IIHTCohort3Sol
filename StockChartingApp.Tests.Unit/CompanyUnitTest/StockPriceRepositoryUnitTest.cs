using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StockChartingApp.CompanyMS.Models;
using StockChartingApp.CompanyMS.Repositories;

namespace StockChartingApp.Tests.Unit.CompanyUnitTest
{
    [TestFixture]
    class StockPriceRepositoryUnitTest
    {
        DbContextOptions<CompanyMSContext> options =
            new DbContextOptionsBuilder<CompanyMSContext>()
            .UseInMemoryDatabase("StockChartingAppDB")
            .Options;

        CompanyMSContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new CompanyMSContext(options);
            context.StockPrice.AddRange(GetStockPriceList());
            context.SaveChanges();
        }

        private IEnumerable<StockPrice> GetStockPriceList()
        {
            return new List<StockPrice>() {
                new StockPrice
                {
                    Id = 1,
                    Price = 150,
                    DateTime = new DateTime(2020,3,9,0,0,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                },
                new StockPrice
                {
                    Id = 2,
                    Price = 160,
                    DateTime = new DateTime(2020,3,9,0,10,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                },
                new StockPrice
                {
                    Id = 3,
                    Price = 170,
                    DateTime = new DateTime(2020,3,9,0,20,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                },
                new StockPrice
                {
                    Id = 4,
                    Price = 180,
                    DateTime = new DateTime(2020,3,9,0,30,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                },
                new StockPrice
                {
                    Id = 5,
                    Price = 190,
                    DateTime = new DateTime(2020,3,9,0,40,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                },
                new StockPrice
                {
                    Id = 6,
                    Price = 200,
                    DateTime = new DateTime(2020,3,9,0,50,0),
                    CompanyId = 2,
                    StockExchangeId = "NSE"
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]
        public void TestGetMultiple()
        {
            //Arrange
            StockPriceRepository repository = new StockPriceRepository(context);

            //Act
            var list = repository.GetMultiple(2,"NSE",new DateTime(2020, 3, 9, 0, 10, 0), new DateTime(2020, 3, 9, 0, 40, 0));

            //Assert
            var actualCount = list.Count();
            Assert.That(actualCount,
                Is.EqualTo(4), "Comapny List does NOT match");
        }
    }
}
