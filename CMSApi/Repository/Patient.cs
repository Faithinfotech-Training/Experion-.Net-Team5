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
        DBClinicContext db;
        public Patient(DBClinicContext _db)
        {
            db = _db;
        }

        public async Task<List<TblPatients>> GetPatients()
        {
            if (db != null)
            {
                return await db.TblPatients.ToListAsync();
            }
            return null;



        }


        #region AddPatients
        //add patients
        public async Task<TblPatients> AddPatients(TblPatients patient)
        {
            if (db != null)
            {
                await db.TblPatients.AddAsync(patient);
                await db.SaveChangesAsync(); //commit the transaction

                return patient;
            }
            return null;
        }


        #endregion


        #region UpdatePatients
        //update patient record
        public async Task<TblPatients> UpdatePatients(TblPatients patient)
        {
            if (db != null)
            {
                db.TblPatients.Update(patient);
                await db.SaveChangesAsync();
                return patient;
            }
            return null;
        }

        #endregion

        

        #region Get Patient By ID        
        public async Task<ActionResult<TblPatients>> GetPatientById(int patientId)
        {
            if (db != null)
            {
                TblPatients test = await db.TblPatients.FirstOrDefaultAsync(em => em.PatientId == patientId);
                return test;
            }
            return null;
        }
        #endregion

        


    }
}

