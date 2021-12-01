using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        //database/json
        DBClinicContext db;

        //Constructor dependency injection
        public AppointmentRepository(DBClinicContext _db)
        {
            db = _db;
        }

        //add appointment
        #region add appointment
        public async Task<int> AddAppointment(TblAppointment appointment)
        {
            if (db != null)
            {
                await db.TblAppointment.AddAsync(appointment);
                await db.SaveChangesAsync();//commit the transaction
                return appointment.AppointmentId;
            }
            return 0;
        }


        #endregion

        //update appointment
        #region update appointment
        public async Task UpdateAppointment(TblAppointment appointment)
        {
            if (db != null)
            {
                db.TblAppointment.Update(appointment);
                await db.SaveChangesAsync();//commit the transaction

            }
        }
        #endregion

        //get appointment details
        #region get appointment details
        public async Task<List<AppointmentViewModel>> GetAppointment()
        {
            if (db != null)
            {
                //LINQ
                return await (from a in db.TblAppointment
                              from p in db.Patients
                              from d in db.Doctors
                              where a.PatientId == p.PatientId
                              where a.DoctorId == d.DoctorId
                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  Contact = p.Contact,
                                  DoctorId = a.DoctorId,
                                  DoctorName = d.DoctorName,
                                  AppointmentDate = a.AppointmentDate,
                                  IsActive = p.IsActive

                              }
                             ).ToListAsync();
            }
            return null;
        }
        #endregion

        //get appointment details by id
        #region get appointment by id
        public async Task<AppointmentViewModel> GetAppointmentById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient
                return await (from a in db.TblAppointment
                              from p in db.Patients
                              from d in db.Doctors
                              where a.AppointmentId == id && a.PatientId == p.PatientId
                              where a.AppointmentId == id && a.DoctorId == d.DoctorId
                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  Contact = p.Contact,
                                  DoctorId = a.DoctorId,
                                  DoctorName = d.DoctorName,
                                  AppointmentDate = a.AppointmentDate,
                                  IsActive = p.IsActive
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
    }
}
