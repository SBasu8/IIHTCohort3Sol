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
    [TestFixture]
    class IPORepositoryUnitTest
    {
        DbContextOptions<StockExchangeContext> options = new DbContextOptionsBuilder<StockExchangeContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        StockExchangeContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new StockExchangeContext(options);
            context.IPODetails.AddRange(GetIPOList());
            context.SaveChanges();
        }

        private IEnumerable<IPODetails> GetIPOList() 
        {
            return new List<IPODetails>() {
                new IPODetails{
                    RegisteredCompanyId = 1,
                    OfferingDateTime = new DateTime(),
                    PricePerShare = 0.98,
                    RegisteredStockExchangeId = "NYSE",
                    Remarks = "Excellent",
                    TotalShares = 1000
                }
            }; 
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]

        public void Test_GetAll_ShouldReturnIPOList()
        {
            //Arrange
            IRepository<IPODetails> repository = new IPORepository(context);

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(GetIPOList().Count()),
                "Comapny List does NOT match");

        }
    }
}
