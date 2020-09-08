using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.SectorMS.Repositories;
using DtoLibraryStockChartingApp;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860 
namespace StockChartingApp.SectorMS.Controllers
{
    [Route("api/sectorms")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class SectorMSController : ControllerBase
    {
        private IRepository<Sector> repository;

        public SectorMSController(IRepository<Sector> repository)
        {
            this.repository = repository;
        }

        // GET: api/<SectorController>
        [HttpGet("getallsectors")]
        public List<SectorDto> GetAllSector()
        {

            var lst = repository.GetAll();
            List<SectorDto> secdto = new List<SectorDto>();
            foreach (Sector sec_ in lst)
            {
                SectorDto secd = new SectorDto();
                secd.Id = sec_.Id;
                secd.SectorName = sec_.SectorName;
                secd.About = sec_.About;
                secdto.Add(secd);
            }
            return secdto;
        }

        // GET api/<SectorController>
        [HttpGet("getcompanylist/{id}")]
        public List<string> GetSectorCompanyList(int id)
        {

            return repository.GetComp(id);


        }

        // POST api/<SectorController>
        [HttpPost("addnewsector")]
        public IActionResult AddSector(SectorDto sector)
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
        [HttpPut("updatecompany/{CompId}/{SecId}")]
        public IActionResult UpdateSectorCompanyList(int CompId,int SecId)
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
        [HttpPut("updatesector/{id}")]
        public IActionResult PutUpdateCompanyDetails(int id, SectorDto sec)
        {
            if (ModelState.IsValid)
            {
                if (id == sec.Id)
                {
                    (bool updated, int status) = repository.UpdateSectorDetails(sec);
                    if (updated)
                    {
                        return Ok(sec);
                    }
                    else
                    {
                        if (status == 1)
                        {
                            return NotFound("Sector not found");
                        }
                    }
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
