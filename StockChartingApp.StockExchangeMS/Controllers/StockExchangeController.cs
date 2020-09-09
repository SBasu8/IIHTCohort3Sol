using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.StockExchangeMS.Repositories;
using StockChartingApp.StockExchangeMS.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.StockExchangeMS.Controllers
{

    [Route("api/stockexchangems")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        private StockExchangeService se_service;
        private GetAllCompanyListService g_service;
        private JoinCompanyStockExchangeService j_c_se_Service;
        private StockPriceService sp_Service;

        //private IRepository<StockExchange> repository;

        public StockExchangeController(StockExchangeService se_service, GetAllCompanyListService g_service, JoinCompanyStockExchangeService j_c_se_Service, StockPriceService sp_Service)
        {
            //this.repository = repository;
            this.se_service = se_service;
            this.g_service = g_service;
            this.j_c_se_Service = j_c_se_Service;
            this.sp_Service = sp_Service;
        }

        [HttpGet]
        public string Get()
        {
            return "Stock Exchange Microservice for Stock Charting App";
        }

        // GET: api/<StockExchangeController>

        [HttpGet("getallstockexchanges")]
        [Authorize(Roles = "ADMIN,USER" )]
        public IEnumerable<StockExchange> GetAll()
        {
            return se_service.GetAll();
        }

        // GET api/<StockExchangeController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public StockExchange Get(string id)
        {
            return se_service.Get(id);
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Post( StockExchange stockExchange)
        {
            if (ModelState.IsValid)
            {
                var isAdded = se_service.Add(stockExchange);
                if (isAdded) return Created("StockExchange", stockExchange);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<StockExchangeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockExchangeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //------------------Get List of Companies-----------------------------------
        [HttpGet("GetCompany/{id}")]
        [Authorize(Roles = "ADMIN")]
        public  IEnumerable<Company> GetCompanies(string id)
        {
            return g_service.GetAllCompaniesList(id);
        }


        //----------------CRUD Company-StockExchange Relationship----------------------------------

        

        [HttpDelete("delete_C_SE/{c_id}/{se_id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteJoinCompanyStockExchangeRelationship(int c_id, string se_id)
        {
            var jcse = j_c_se_Service.Get(c_id, se_id);
            if (jcse == null) return NotFound();

            var isDeleted = j_c_se_Service.Delete(jcse);
            if (isDeleted) return Ok("Company-StockExchange Relationship Deleted Succesfully");

            return StatusCode(500, "Internal Server Error");
        }

        //----------------------CRUD Stock Price-------------------------------
        
        [HttpPost("StockPrice")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Post( StockPrice stockprice)
        {
            if (ModelState.IsValid)
            {
                var isAdded = sp_Service.Add(stockprice);
                if (isAdded) return Created("StockExchange", stockprice);
            }   
            return BadRequest(ModelState);
        }

        [HttpGet("GetStockPrices")]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<StockPrice> GetStockPrices()
        {
            return sp_Service.GetAllStockPrice();
        }

    }
}
