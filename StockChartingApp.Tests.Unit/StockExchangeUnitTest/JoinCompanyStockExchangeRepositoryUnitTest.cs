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
    class JoinJoinCompanyStockExchangeStockExchangeRepositoryUnitTest
    {
        DbContextOptions<StockExchangeContext> options = new DbContextOptionsBuilder<StockExchangeContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        StockExchangeContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new StockExchangeContext(options);
            context.JoinCompanyStockExchange.AddRange(GetJoinCompanyStockExchangeList());
            context.SaveChanges();
        }

        private IEnumerable<JoinCompanyStockExchange> GetJoinCompanyStockExchangeList() 
        {
            return new List<JoinCompanyStockExchange>()
            {
                new JoinCompanyStockExchange(){
                    CompanyId=1,
                    StockExchangeId = "NYSE"
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]

        public void Test_GetAll_ShouldReturnJoinCompanyStockExchangeList()
        {
            //Arrange
            IJoinRepository<JoinCompanyStockExchange> repository = new JoinCompanyStockExchangeRepository(context);

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(GetJoinCompanyStockExchangeList().Count()),
                "Comapny List does NOT match");

        }
    }
}
