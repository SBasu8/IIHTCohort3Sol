using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StockChartingApp.SectorMS.Models;
using StockChartingApp.SectorMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DtoLibraryStockChartingApp;

namespace StockChartingApp.Tests.Unit.SectorUnitTest
{
    [TestFixture]
    class SectorRepositoryUnitTest
    {
        DbContextOptions<SectorMSContext> options = new DbContextOptionsBuilder<SectorMSContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        SectorMSContext context = null;

        private Sector GetSector()
        {
            Sector s = new Sector();
            s.Id = 3;
            s.SectorName = "Tech";
            s.About = "Technology Companies";
            s.Companies = new List<Company>();
            return s;
        }
        [SetUp]
        public void Setup()
        {

            context = new SectorMSContext(options);

        }



        private Company GetCompany()
        {
            Company c = new Company();
            c.Id = 1;
            c.CompanyName = "Reliance";
            c.Ceo = "Mukesh";
            c.About = "A good company";
            c.Turnover = 1000;
            c.BusinessSector = GetSector();
            c.Ipos = new List<IPODetails>();
            c.JoinCompanyBod = new List<JoinCompanyBoardMember>();
            c.JoinCompanyExchanges = new List<JoinCompanyStockExchange>();
            c.CurrentPrices = new List<StockPrice>();

            return c;
        }

        [TearDown]
        public void Teardown()
        {

            if (context != null) context.Dispose();
        }


        public void Test_Update_ShouldUpdateSector()
        {
            IRepository<Sector> repository = new SectorRepository(context);
            context.Sector.Add(GetSector());
            SectorDto s1 = new SectorDto();
            s1.Id = 3;
            s1.SectorName = "Construction";
            s1.About = "Construction Companies";

            //Act
            var sec_ = repository.UpdateSectorDetails(s1);
            Sector s2 = context.Sector.Find(GetSector().Id);
            //Assert

            Console.WriteLine(sec_);
            Assert.That(s2.SectorName,
                Is.EqualTo("Construction"),
                "Sector List does NOT match");

        }



    }
    
}