using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using StockChartingApp.StockExchangeMS.Models;
using StockChartingApp.StockExchangeMS.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StockChartingApp.Tests.Unit.StockExchangeUnitTest
{
    [TestFixture]
    class CompanyRepositoryUnitTest
    {
        DbContextOptions<StockExchangeContext> options = new DbContextOptionsBuilder<StockExchangeContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        StockExchangeContext context = null;


        [SetUp]
        public void Setup()
        {
            context = new StockExchangeContext(options);
            context.Company.AddRange(GetCompanyList());
            context.SaveChanges();
        }

        private IEnumerable<Company> GetCompanyList()
        { 
            return new List<Company>() {
                new Company{
                    Id = 1,
                    CompanyName = "C1",
                    Turnover = 100,
                    Ceo="Sundar Pichai",
                    About = "Good company"
                }
            };
        }
        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]
        
        public void Test_GetAll_ShouldReturnCompanyList()
        {
            //Arrange
            IRepository<Company> repository = new CompanyRepository(context);

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(GetCompanyList().Count()),
                "Comapny List does NOT match");

        }


    }
}
