using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.RoleMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.RoleMS.Controllers
{
    [Route("api/rolems")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepository<Role> repository;

        public AuthController(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("Login")]
        public IActionResult Get(string uname, string pass)
        {

            if (!(string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pass)))
            {
                try
                {
                    var res = repository.Login(uname, pass);
                    if (res.Item1) return Ok(res.Item2);

                    return BadRequest("Invalid creds");
                }
                catch (Exception) { return StatusCode(500, "Internal Server Error"); }
            }
            else return BadRequest("Enter Both UserName & Password");
            
        }


        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromForm] Role role)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Signup(role);
                if (isAdded) return Created("Role", role);
                return BadRequest();
            }
            return BadRequest(); 
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
