using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Services
{
    public class BoardMemberService
    {
        private BoardMemberRepository repository;
        private CompanyService company_service;

        public BoardMemberService(BoardMemberRepository repository, CompanyService company_service)
        {
            this.repository = repository;
            this.company_service = company_service;
        }
        public bool InsertNewBoardMember(BoardMember bm)
        {
            bm.JoinCompanyBod = new List<JoinCompanyBoardMember>();
            return repository.Add(bm);
        }

        public (bool,int) AddRelationshipWithCompany(int bm_id,int comp_id)
        {
            var existing_bm = repository.GetSingle(bm_id);
            if(existing_bm==null)
            {
                return (false, 1);
            }

            var existing_company = company_service.GetExistingCompany(comp_id);
            if(existing_company==null)
            {
                return (false, 2);
            }

            var add_company_bm_relationship = 
                repository.AddCompanyRelatioship(new JoinCompanyBoardMember 
                { BoardMember=existing_bm, Company=existing_company });

            return (add_company_bm_relationship, 0);
        }

        public bool RemoveRelationshipWithCompany(int bm_id, int comp_id)
        {
            return repository.RemoveCompanyRelatioship(bm_id, comp_id);
        }
    }
}
