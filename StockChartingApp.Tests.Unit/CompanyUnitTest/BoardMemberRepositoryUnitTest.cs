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
    class BoardMemberRepositoryUnitTest
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
        }

        private IEnumerable<BoardMember> GetBoardMemberList()
        {
            return new List<BoardMember>() {
                new BoardMember{
                    Id = 1,
                    Name = "Prabin"
                },
                new BoardMember{
                    Id = 2,
                    Name = "Suvronil"
                },
                new BoardMember{
                    Id = 3,
                    Name = "Avi"
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context != null) context.Dispose();
        }

        [Test]
        public void TestAddMultiple()
        {
            //Arrange
            BoardMemberRepository repository = new BoardMemberRepository(context);

            //Act
            var added = repository.AddMultiple(GetBoardMemberList());

            //Assert
            var actualCount = context.BoardMember.Count();
            Assert.That(actualCount,
                Is.EqualTo(3), "Comapny List does NOT match");
        }
    }
}
