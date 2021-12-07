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
                              from d in db.Dtests
                              where n.TestId == d.TestNameId && d.PatientId == id

                              select new TestNameViewModel
                              {
                                  TestId =n.TestId,
                                  PatientId=d.PatientId,
                                  TestName=n.TestName,
                                  NormalRange=n.NormalRange,
                                  TestDate=d.TestDate,
                              }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
