using EntityLibraryStockChartingApp;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StockChartingApp.SectorMS.Models;
using StockChartingApp.SectorMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockChartingApp.Tests.Unit.SectorUnitTest
{
    [TestFixture]
    class SectorRepositoryUnitTest
    {
        DbContextOptions<SectorMSContext> options = new DbContextOptionsBuilder<SectorMSContext>()
                                                                    .UseInMemoryDatabase("StockChartingAppDB")
                                                                    .Options;

        SectorMSContext context = null;

        private IEnumerable<Sector> GetSectorList()
        {
            return new List<Sector>()
            {
                new Sector(){
                    Id=2,
                    SectorName = "Mining",
                    About="Digging Mines",
                    Companies = new List<Company>()
                }
            };
        }
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
            //context.Sector.AddRange(GetSectorList());
            
           


           //context.SaveChanges();
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

        [Test]
        public void Test_Add_ShouldAddSector()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
            context.Sector.Add(GetSector());
            // repository.Add(GetSector());
            //Act

            var sec_ = context.Sector.Find(GetSector().Id);
            //Assert
            //var actualCount = list.Count();

            Console.WriteLine(sec_);
            Assert.That(sec_.Id,
                Is.EqualTo(3),
                "Sector List does NOT match");

        }
        [Test]

        public void Test_GetAll_ShouldReturnSectorList()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
            
           

            //Act
            var list = repository.GetAll();

            //Assert
            var actualCount = list.Count();
            Console.WriteLine(actualCount);
            Assert.That(actualCount,
                Is.EqualTo(1),
                "Sector List does NOT match");

        }

        [Test]
        public void Test_Get_ShouldReturnCompany()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
            context.Company.Add(GetCompany());

            //Act
            var comp_ = repository.GetSingleCompany(GetCompany().Id);

            //Assert
            //var actualCount = list.Count();

            Console.WriteLine(comp_.Id);
            Assert.That(comp_.Id,
                Is.EqualTo(GetCompany().Id),
                "Company does NOT match");

        }
        [Test]
        public void Test_Get_ShouldReturnSector()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
           // repository.Add(GetSector());

            //Act
            var sec_ = repository.GetSingleSector(GetSector().Id);

            //Assert
            //var actualCount = list.Count();

            Console.WriteLine(sec_.Id);
            Assert.That(sec_.Id,
                Is.EqualTo(GetSector().Id),
                "Sector does NOT match");

        }



        [Test]
        public void Test_Get_ShouldReturnCompanyList()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
            //context.Company.Add(GetCompany());
            //context.Sector.Add(GetSector());
            Sector s = GetSector();

            var list = repository.GetCompanyList(s.Id);

            //Act
           
            // context.SaveChangesAsync();
            //var list = repository.GetCompanyList(GetSector().Id);
            // var list = GetSector().Companies;

            //Assert
            //var actualCount = list.Count();

            Console.WriteLine(1);
            Assert.That(list.Count(),
                Is.EqualTo(1),
                "Company list does NOT get updated");

        }



        [Test]
        public void Test_Update_ShouldUpdateCompanyList()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);
            //context.Company.Add(GetCompany());
            //context.Sector.Add(GetSector());
            Sector s = GetSector();



            //Act
            bool p = repository.UpdateCompany(GetCompany(), s);
            // context.SaveChangesAsync();
            //var list = repository.GetCompanyList(GetSector().Id);
            // var list = GetSector().Companies;

            //Assert
            //var actualCount = list.Count();

            Console.WriteLine(1);
            Assert.That(s.Companies.Count(),
                Is.EqualTo(1),
                "Company list does NOT get updated");

        }

    }
}