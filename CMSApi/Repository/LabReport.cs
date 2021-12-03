using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class LabReport : ILabReport
    {
        DBClinicContext db;

        //Constructor dependency injection
        public LabReport(DBClinicContext _db)
        {
            db = _db;
        }
        #region Get Report using ViewModel
        public async Task<List<LabReportViewModel>> GetLabReports(int id)
        {
            if (db != null)
            {
                //LINQ
                //join post and category
                return await (from l in db.TblLabReport
                              from d in db.Doctors
                              from s in db.Staffs
                              where l.DoctorId == d.DoctorId
                              where l.StaffId == s.StaffId
                              where l.ReportId == id
                              select new LabReportViewModel
                              {
                                  ReportId = l.ReportId,
                                  ReportNumber = l.ReportNumber,
                                  ReportDate = l.ReportDate,
                                  ReportNotes = l.ReportNotes,
                                  PatientId = l.PatientId,
                                  IsActive = l.IsActive,
                                  StaffId = l.StaffId,
                                  DoctorId = l.DoctorId,
                                  DoctorName = d.DoctorName,
                                  StaffName = s.StaffName
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Report using ViewModel
        public async Task<List<LabReportViewModel>> GetLabReports()
        {
            if (db != null)
            {
                //LINQ
                //join post and category
                return await (from l in db.TblLabReport 
                              from d in db.Doctors
                              from s in db.Staffs
                              where l.DoctorId == d.DoctorId
                              where l.StaffId == s.StaffId
                              select new LabReportViewModel
                              {
                                  ReportId = l.ReportId,
                                  ReportNumber = l.ReportNumber,
                                  ReportDate = l.ReportDate,
                                  ReportNotes = l.ReportNotes,
                                  PatientId = l.PatientId,
                                  IsActive = l.IsActive,
                                  StaffId = l.StaffId,
                                  DoctorId = l.DoctorId,
                                  DoctorName = d.DoctorName,
                                  StaffName = s.StaffName
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion
        //view Report
        public async Task<List<TblLabReport>> GetReport()
        {
            if (db != null)
            {
                return await db.TblLabReport.ToListAsync();
            }
            return null;

        }

        #region Add Reports
        public async Task<int> AddReport(TblLabReport report)
        {
            if (db != null)
            {
                await db.TblLabReport.AddAsync(report);
                await db.SaveChangesAsync();
                return report.ReportId;
            }
            return 0;
        }
        #endregion
    }
}
