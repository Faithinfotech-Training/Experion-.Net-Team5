using CMSApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class DoctorRepo:IDoctorRepo
    {
        DBClinicContext db;



        //constructor dependancy injection;
        public DoctorRepo(DBClinicContext _db)
        {
            db = _db;
        }
        #region
        public async Task<List<Doctors>> GetDoctors()
        {

            if (db != null)
            {
                return await db.Doctors.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Doctors
        public async Task<int> AddDoctor(Doctors doc)
        {

            if (db != null)
            {
                await db.Doctors.AddAsync(doc);
                await db.SaveChangesAsync(); //commit the transaction
                return doc.DoctorId;
            }
            return 0;

        }
        #endregion
        #region
        public async Task UpdateDoctor(Doctors doc)
        {
            if (db != null)
            {
                db.Doctors.Update(doc);
                await db.SaveChangesAsync(); //commit the transaction

            }

        }
        #endregion
    }
}
