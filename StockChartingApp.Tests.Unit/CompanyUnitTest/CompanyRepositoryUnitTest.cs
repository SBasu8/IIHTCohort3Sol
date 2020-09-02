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
    class CompanyRepositoryUnitTest
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
            context.Company.AddRange(GetCompanyList());
            context.SaveChanges();
        }

        private IEnumerable<Company> GetCompanyList()
        {
            return new List<Company>() {
                new Company{
                    Id = 1,
                    CompanyName = "Google",
                    Turnover = 100,
                    Ceo="Sundar Pichai",
                    About = "Good company"
                },
                new Company{
                    Id = 2,
                    CompanyName = "Alpha Go",
                    Turnover = 100,
                    Ceo="Shane Legg",
                    About = "Great company"
                },
                new Company{
                    Id = 3,
                    CompanyName = "Wells Fargo",
                    Turnover = 100,
                    Ceo="Charles Scharf",
                    About = "Great company"
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]
        public void TestMatchingCompanies()
        {
            //Arrange
            CompanyRepository repository = new CompanyRepository(context);

            //Act
            var list = repository.MatchingCompanies("Go");

            //Assert
            var actualCount = list.Count();
            Assert.That(actualCount,
                Is.EqualTo(2), "Comapny List does NOT match");
        }
    }
}
