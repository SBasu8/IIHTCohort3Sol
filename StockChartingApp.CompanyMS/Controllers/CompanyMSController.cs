using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtoLibraryStockChartingApp;
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
        private CompanyService company_service;
        private IPODetailsService ipo_service;
        private BoardMemberService bm_service;
        private StockPriceService sp_service;

        public CompanyMSController(CompanyService company_service, IPODetailsService ipo_service, BoardMemberService bm_service, StockPriceService sp_service)
        {
            this.company_service = company_service;
            this.ipo_service = ipo_service;
            this.bm_service = bm_service;
            this.sp_service = sp_service;
        }

        [HttpGet]
        public string Get()
        {
            return "Company Microservice for Stock Charting App";
        }

        //Company specific request handles
        [HttpGet("getcompanydetails/{id}")]
        public IActionResult GetCompanyDetails(int id)
        {
            var company = company_service.GetExistingCompany(id);
            if(company!=null)
            {
                return Ok(company);
            }
            return NotFound("Company not found");
        }

        [HttpGet("getallcompanies")]
        public IActionResult GetAllCompaniesDetails()
        {
            return Ok(company_service.GetAllCompanies());
        }

        [HttpPost("addnewcompany")]
        public IActionResult PostAddNewCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                var isAdded = company_service.InsertNewCompany(company);
                if (isAdded)
                {
                    return Created("Company", company);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("updatecompany/{id}")]
        public IActionResult PutUpdateCompanyDetails(int id, Company company)
        {
            if(ModelState.IsValid)
            {
                if(id == company.Id)
                {
                    (bool updated, int status) = company_service.UpdateCompanyDetails(company);
                    if(updated)
                    {
                        return Ok(company);
                    }
                    else
                    {
                        if(status==1)
                        {
                            return NotFound("Company not found");
                        }                        
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("removecompany/{id}")]
        public IActionResult DeleteRemoveCompany(int id)
        {
            (bool deleted, int status) = company_service.DeleteCompany(id);
            if(deleted)
            {
                return Ok("Company deletd successfully");
            }

            if(status==1)
            {
                return NotFound("Company not found");
            }

            return StatusCode(500, "Internal server error");
        }

        //Company IPO request handles
        [HttpPost("addcompanyipo")]
        public IActionResult PostAddCompanyIPO(IPODetailsDto ipo_dto)
        {
            if (ModelState.IsValid)
            {
                (bool isAdded, int status) = ipo_service.InsertNewIPODetail(ipo_dto);
                if (status == 1)
                {
                    return NotFound("Company not found");
                }
                if (status == 2)
                {
                    return NotFound("Stock Exchange not found");
                }

                if (isAdded)
                {
                    return Created("Added new IPO details",ipo_dto);
                }
                return StatusCode(500, "Internal server error");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("getcompanyipo/{id}/{se_id}")]
        public IActionResult GetCompanyIPOs(int id, string se_id)
        {
            var ipo = ipo_service.GetExistingIPO(id,se_id);
            if(ipo==null)
            {
                return NotFound("IPO not found");
            }
            return Ok(ipo);
        }

        [HttpGet("getallipos")]
        public IActionResult GetAllIPOs()
        {
            return Ok(ipo_service.GetAllExistingIPOs());
        }

        //Board Member relationship
        [HttpPost("addnewboardmember")]
        public IActionResult PostAddNewBoardMamber(BoardMember member)
        {
            if(ModelState.IsValid)
            {
                var added = bm_service.InsertNewBoardMember(member);
                if(added)
                {
                    return Created("Added new member",member);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("addcompanybm/{bm_id}/{id}")]
        public IActionResult PutAddBoardMemberRelationship(int bm_id,int id)
        {
            (bool isAdded, int status) = bm_service.AddRelationshipWithCompany(bm_id,id);
            if (status == 1)
            {
                return NotFound("Board Member not found");
            }
            if (status == 2)
            {
                return NotFound("Company not found");
            }

            if (isAdded)
            {
                return Ok("Relationship added successfully");
            }
            return StatusCode(500, "Internal server error");
        }

        [HttpDelete("removecompanybm/{bm_id}/{id}")]
        public IActionResult DeleteRemoveBoardMemberRelationship(int bm_id, int id)
        {
            var deleted = bm_service.RemoveRelationshipWithCompany(bm_id,id);
            if(deleted)
            {
                return Ok("Relationship deleted successfully");
            }
            return StatusCode(500, "Internal server error");
        }

        //Feature request
        [HttpGet("matchingcompanies")] //partial_name is a paramater
        public IActionResult GetMatchingCompanies(string partial_name)
        {
            return Ok(company_service.FetchMatchingCompanies(partial_name));
        }

        [HttpPost("companystockprices")]
        public IActionResult GetComapnyStockPrices(StockPriceRequestDto spq)
        {
            if (ModelState.IsValid)
            {
                return Ok(sp_service.FetchComapnyStockPrices(spq));
            }
            return BadRequest(ModelState);
        }
    }
}
