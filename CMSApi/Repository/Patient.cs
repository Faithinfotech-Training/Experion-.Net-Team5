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
    public class Patient : IPatient
    {
        private DBClinicContext db;
        public Patient(DBClinicContext _db)
        {
            db = _db;
        }
        #region GetAllPatients

        //get all patients
        public async Task<List<Patients>> GetAllPatients()
        {
            if (db != null)
            {
                return await db.Patients.ToListAsync();
            }
            return null;

        }
        #endregion

        #region AddPatients
        //add patients
        public async Task<Patients> AddPatients(Patients patient)
        {
            if (db != null)
            {
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync(); //commit the transaction

                return patient;
            }
            return null;
        }


        #endregion


        #region UpdatePatients
        //update patient record
        public async Task<Patients> UpdatePatients(Patients patient)
        {
            if (db != null)
            {
                db.Patients.Update(patient);
                await db.SaveChangesAsync();
                return patient;
            }
            return null;
        }

        #endregion

        #region GetPatient
        public async Task<PatientViewModel> GetPatient(int id)
        {
            if (db != null)
            {
                return await (from d in db.Doctors
                              join c in db.Consultings
                              on d.DoctorId equals c.DoctorId
                              join p in db.Patients
                              on c.PatientId equals p.PatientId
                              where p.PatientId == id
                              select new PatientViewModel
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  DoctorId = d.DoctorId,
                                  ConsultingDate = c.ConsultingDate,
                                  DoctorName = d.DoctorName
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region GetPatientDetails
        public async Task<TestViewModel> GetPatientDetails(int id)
        {
            if (db != null)
            {
                return await (from p in db.Patients
                              join c in db.Consultings
                              on p.PatientId equals c.PatientId
                              join pr in db.Prescriptions
                              on c.ConsultingId equals pr.ConsultingId
                              join m in db.Medicines
                              on pr.PrescriptionId equals m.PrescriptionId
                              join t in db.Tests
                              on pr.TestId equals t.TestId
                              join r in db.Results
                              on t.TestId equals r.TestId
                              where p.PatientId == id
                              select new TestViewModel
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  ConsultingDate = c.ConsultingDate,
                                  DoctorNotes = pr.DoctorNotes,
                                  MedicineName = m.MedicineName,
                                  Quantity = m.Quantity,
                                  TestNames = t.TestNames,
                                  Result = r.Result


                              }).FirstOrDefaultAsync();


            }
            return null;
        }
        #endregion

        #region Get Patient By ID        
        public async Task<ActionResult<Patients>> GetPatientById(int patientId)
        {
            if (db != null)
            {
                Patients test = await db.Patients.FirstOrDefaultAsync(em => em.PatientId == patientId);
                return test;
            }
            return null;
        }
        #endregion

    }
}

