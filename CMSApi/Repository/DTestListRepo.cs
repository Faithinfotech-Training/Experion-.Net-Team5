using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CMSApi.Repository
{
    public class DTestListRepo : IDTestList
    {
        DBClinicContext db;

        //constructor dependancy injection;
        public DTestListRepo(DBClinicContext _db)
        {
            db = _db;
        }

        #region GetAppointmentByDoctorIdAndDate()
        public async Task<List<PatientTestViewModel>> GetTestByPatientId(int id)
        {
            if (db != null)
            {
                //LINQ
                //join dtests, ntest,tblpatient,doctors
                return await (from a in db.Ntests
                              from p in db.Dtests
                              from d in db.TblPatients

                              where d.PatientId == id && p.PatientId == d.PatientId && a.TestId == p.TestNameId
                              select new PatientTestViewModel
                              {
                                  TestName = a.TestName,
                                  TestDate = p.TestDate,


                              }).ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
