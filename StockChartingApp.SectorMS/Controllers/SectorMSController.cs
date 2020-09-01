using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.SectorMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.SectorMS.Controllers
{
    [Route("api/sectorms")]
    [ApiController]
    public class SectorMSController : ControllerBase
    {
        private IRepository<Sector> repository;

        public SectorMSController(IRepository<Sector> repository)
        {
            this.repository = repository;
        }

        // GET: api/<SectorController>
        [HttpGet]
        public string GetAllSector()
        {

            return "Sector Microservice for Stock Charting App";

        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        public List<string> GetSectorCompanyList(int id)
        {

            return repository.GetComp(id);


        }

        // POST api/<SectorController>
        [HttpPost]
        public IActionResult AddSector([FromForm] Sector sector)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(sector);
                if (isAdded)
                {
                    return Created("Sector", sector);
                }
            }
            return BadRequest(ModelState);

        }


        // PUT api/<SectorController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSectorCompanyList(int CompId, int SecId)
        {
             if (ModelState.IsValid)
             {
                 var isUpdated = repository.UpdateCompanyList(CompId, SecId);
                 if (isUpdated)
                 {
                     return Ok();
                 }
             }
             return BadRequest(ModelState);
           

        }


        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
