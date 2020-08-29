using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.StockExchangeMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.StockExchangeMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        private IRepository<StockExchange> repository;

        public StockExchangeController(IRepository<StockExchange> repository)
        {
            this.repository = repository;
        }

        // GET: api/<StockExchangeController>
        [HttpGet]
        public IEnumerable<StockExchange> Get()
        {
            return repository.GetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<StockExchangeController>/5
        [HttpGet("{id}")]
        public StockExchange Get(string id)
        {
            return repository.Get(id);
        }

        // POST api/<StockExchangeController>
        [HttpPost]
        public IActionResult Post([FromForm] StockExchange stockExchange)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(stockExchange);
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
    }
}
