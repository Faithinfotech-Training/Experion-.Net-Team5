using CMSApi.Models;
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

        

        
    }
}
