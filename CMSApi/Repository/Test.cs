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
        #region Get Test By Patient Id        
        public async Task<List<test>> GetTestByPatientId(int id)
        {
            if (db != null)
            {
                //LINQ
                return await (from t in db.Tests
                              where t.PatientId == id
                              select new test
                              {
                                  TestId = t.TestId,
                                  TestName = t.TestName,
                                  NormalRange = t.NormalRange,
                                  TestResult = t.TestResult,
                                  IsActive = t.IsActive,
                                  PatientId = t.PatientId,
                                  DoctorId =t.DoctorId,
                                  StaffId = t.StaffId
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Test
        public async Task<int> AddTest(test test)
        {
            if (db != null)
            {
                await db.Tests.AddAsync(test);
                await db.SaveChangesAsync();
                return test.TestId;
            }
            return 0;
        }
        #endregion

        //Update test
        #region Update Test
        public async Task UpdateTest(test test)
        {
            if (db != null)
            {
                db.Tests.Update(test);
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
        public async Task<List<test>> GetTest()
        {
            if (db != null)
            {
                return await db.Tests.ToListAsync();
            }
            return null;



        }
    }
    

}
