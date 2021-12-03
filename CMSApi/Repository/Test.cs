using CMSApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class Test :ITest
    {
        //database connection
        DBClinicContext db;

        //Constructor dependency injection
        public Test(DBClinicContext _db)
        {
            db = _db;
        }
        #region Get Test By Report Id        
        public async Task<List<TblTest>> GetTestByReportId(int id)
        {
            if (db != null)
            {
                //LINQ
                return await (from t in db.TblTest
                              where t.ReportId == id
                              select new TblTest
                              {
                                  TestId = t.TestId,
                                  TestName = t.TestName,
                                  NormalRange = t.NormalRange,
                                  TestResult = t.TestResult,
                                  IsActive = t.IsActive,
                                  ReportId = t.ReportId,
                                  StaffId = t.StaffId
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Test
        public async Task<int> AddTest(TblTest test)
        {
            if (db != null)
            {
                await db.TblTest.AddAsync(test);
                await db.SaveChangesAsync();
                return test.TestId;
            }
            return 0;
        }
        #endregion

        //Update test
        #region Update Test
        public async Task UpdateTest(TblTest test)
        {
            if (db != null)
            {
                db.TblTest.Update(test);
                await db.SaveChangesAsync();    //Commit the transaction
            }
        }
        #endregion

        #region
        public async Task<List<Staffs>> GetStaffbyId(int id)
        {
            if (db != null)
            {
                //LINQ
                return await (from s in db.Staffs
                              where s.DepartmentId == id
                              select new Staffs
                              {
                                  StaffId = s.StaffId,
                                  StaffName = s.StaffName,
                                  
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
