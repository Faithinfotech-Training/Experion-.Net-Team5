using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class TestNameRepo :ITestNameRepo
    {
        //database/json
        DBClinicContext db;

        //Constructor dependency injection
        public TestNameRepo(DBClinicContext _db)
        {
            db = _db;
        }






        #region get Test by id
        public async Task<List<TestNameViewModel>> GetTestById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient
                return await (from n in db.Ntests
                              join d in db.Dtests
                              on n.NtestId equals d.TestNameId 
                              join r in db.TestResult
                              on d.TestId equals r.TestId
                              where d.PatientId == id

                              select new TestNameViewModel
                              {
                                  TestId =n.NtestId,
                                  PatientId=d.PatientId,
                                  TestNameId=d.TestNameId,
                                  DoctorId=d.DoctorId,
                                  IsActive=d.IsActive,
                                  TestName=n.TestName,
                                  Result = r.Result,
                                  NormalRange=n.NormalRange,
                                  TestDate=d.TestDate,
                              }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
