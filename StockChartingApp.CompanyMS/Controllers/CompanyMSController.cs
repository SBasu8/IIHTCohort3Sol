using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.CompanyMS.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.CompanyMS.Controllers
{
    [Route("api/companyms")]
    [ApiController]
    public class CompanyMSController : ControllerBase
    {
        private AddNewCompany newCompany;

        public CompanyMSController(AddNewCompany newCompany)
        {
            this.newCompany = newCompany;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World !!!" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var company = newCompany.GetExistingCompany(id);
            if(company!=null)
            {
                return Ok(company);
            }

            return NotFound();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromForm] Company company)
        {
            if (ModelState.IsValid)
            {
                var isAdded = newCompany.InsertNewCompany(company);
                if (isAdded)
                {
                    return Created("Company", company);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
