using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockChartingApp.UploadExcelMS.Models;
using StockChartingApp.UploadExcelMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockChartingApp.UploadExcelMS.Controllers
{
    [Route("api/uploadexcel")]
    [ApiController]
    public class UploadExcelController : ControllerBase
    {
        private IUploadExcelRepository<AppDBContext> repository;

        public UploadExcelController(IUploadExcelRepository<AppDBContext> repository)
        {
            this.repository = repository;
        }

        // GET: api/<UploadExcelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UploadExcelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UploadExcelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UploadExcelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UploadExcelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file1)
        {
            if (file1 == null)
            {
                return BadRequest("must upload a file");
            }
            //check file extension

            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    repository.UploadExcel(fullPath);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}
