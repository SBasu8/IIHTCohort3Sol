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
    //[Authorize(Roles = "ADMIN")]
    public class StockExchangeController : ControllerBase
    {
        private StockExchangeService service;
        private GetAllCompanyListService g_service;
        private JoinCompanyStockExchangeService aj_c_seService;
        private StockPriceService a_spService;

        //private IRepository<StockExchange> repository;

        public StockExchangeController(StockExchangeService service, GetAllCompanyListService g_service, JoinCompanyStockExchangeService aj_c_seService, StockPriceService a_spService)
        {
            //this.repository = repository;
            this.service = service;
            this.g_service = g_service;
            this.aj_c_seService = aj_c_seService;
            this.a_spService = a_spService;
        }

        // GET: api/<StockExchangeController>
        
        [HttpGet]
        public IEnumerable<StockExchange> Get()
        {
            return service.GetAll();
        }

        // GET api/<StockExchangeController>/5
        [HttpGet("{id}")]
        public StockExchange Get(string id)
        {
            return service.Get(id);
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        public IActionResult Post([FromForm] StockExchange stockExchange)
        {
            if (ModelState.IsValid)
            {
                var isAdded = service.Add(stockExchange);
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
        [HttpGet("api/GetCompany/{id}")]
        public  IEnumerable<Company> GetCompanies(string id)
        {
            return g_service.GetAllCompaniesList(id);
        }


        //----------------CRUD Company-StockExchange Relationship----------------------------------

        

        [HttpDelete("delete_C_SE/{c_id}/{se_id}")]
        public IActionResult DeleteJoinCompanyStockExchangeRelationship(int c_id, string se_id)
        {
            var jcse = aj_c_seService.Get(c_id, se_id);
            if (jcse == null) return NotFound();

            var isDeleted = aj_c_seService.Delete(jcse);
            if (isDeleted) return Ok("Company-StockExchange Relationship Deleted Succesfully");

            return StatusCode(500, "Internal Server Error");
        }

        //----------------------CRUD Stock Price-------------------------------
        
        [HttpPost("StockPrice")]
        public IActionResult Post([FromForm] StockPrice stockprice)
        {
            if (ModelState.IsValid)
            {
                var isAdded = a_spService.Add(stockprice);
                if (isAdded) return Created("StockExchange", stockprice);
            }
            return BadRequest(ModelState);
        }



    }
}
