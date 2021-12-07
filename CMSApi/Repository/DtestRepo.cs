using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class DtestRepo:IDtest
    {
        DBClinicContext db;
        //constructor dependancy injection;
        public DtestRepo(DBClinicContext _db)
        {
            db = _db;
        }
        #region Add Tests
        public async Task<int> AddTest(Dtests test)
        {

            if (db != null)
            {
                await db.Dtests.AddAsync(test);
                await db.SaveChangesAsync(); //commit the transaction
                return test.TestId;
            }
            return 0;

        }
        #endregion

        #region
        public async Task<List<Dtests>> GetTests()
        {

            if (db != null)
            {

                return await db.Dtests.ToListAsync();
            }
            return null;
        }
        #endregion
        public async Task<List<Ntests>> GetTestName()
        {

            if (db != null)
            {
                return await db.Ntests.ToListAsync();
            }
            return null;
        }
        #region GetAppointmentByDoctorIdAndDate()
        public async Task<List<LabTestAppViewModel>> GetLabAppointmentByDate(DateTime date)
        {
            if (db != null)
            {
                //LINQ
                //join dtest, ntest, patient,doctor
                return await (from a in db.Dtests
                              from n in db.Ntests
                              from p in db.TblPatients
                              from d in db.Doctors
                              where a.TestDate == date && a.TestNameId == n.NtestId && a.DoctorId == d.DoctorId && a.PatientId == p.PatientId
                              select new LabTestAppViewModel
                              {
                                  TestId = a.TestId,
                                  TestName = n.TestName,
                                  TestDate = a.TestDate,
                                  NormalRange = n.NormalRange,
                                  DoctorId = a.DoctorId,
                                  DoctorName = d.DoctorName,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  IsActive = a.IsActive
                              }).ToListAsync();
            }
            return null;
        }

        #endregion
        #region Add Test
        public async Task<int> AddTestReport(TestResult test)
        {
            if (db != null)
            {
                await db.TestResult.AddAsync(test);
                await db.SaveChangesAsync();
                return test.ResultId;
            }
            return 0;
        }
        #endregion

        public async Task<List<Dtests>> Gettest()
        {
            if (db != null)
            {
                return await db.Dtests.ToListAsync();
            }
            return null;



        }

        public async Task<List<TestResult>> Getresult()
        {
            if (db != null)
            {
                return await db.TestResult.ToListAsync();
            }
            return null;



        }
    }
}
