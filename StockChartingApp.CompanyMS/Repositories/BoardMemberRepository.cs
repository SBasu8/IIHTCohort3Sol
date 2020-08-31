using EntityLibraryStockChartingApp;
using StockChartingApp.CompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChartingApp.CompanyMS.Repositories
{
    public class BoardMemberRepository
    {
        private CompanyMSContext context;

        public BoardMemberRepository(CompanyMSContext context)
        {
            this.context = context;
        }
        public bool Add(BoardMember bm)
        {
            try
            {
                context.BoardMember.Add(bm);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddMultiple(IEnumerable<BoardMember> bms)
        {

            try
            {
                foreach(BoardMember bm in bms)
                {
                    context.BoardMember.Add(bm);
                }
                
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BoardMember GetSingle(object key)
        {
            try
            {
                var bm = context.BoardMember.Find(key);
                return bm;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(BoardMember bm)
        {
            try
            {
                context.BoardMember.Remove(bm);
                var updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddCompanyRelatioship(JoinCompanyBoardMember join_cbm)
        {
            try
            {
                context.JoinCompanyBoardMember.Add(join_cbm);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCompanyRelatioship(int bm_id,int comp_id)
        {
            try
            {
                context.JoinCompanyBoardMember.Remove
                    (new JoinCompanyBoardMember { CompanyId=comp_id, BoardMemberId=bm_id });
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
