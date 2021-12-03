using CMSApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class MedicineRepo : IMedicineRepo
    {
        DBClinicContext db;

        //Constructor dependency injection
        public MedicineRepo(DBClinicContext _db)
        {
            db = _db;
        }

        //add appointment
        #region add appointment
        public async Task<int> AddMedicine(TbllMedicines medicine)
        {
            if (db != null)
            {
                await db.TbllMedicines.AddAsync(medicine);
                await db.SaveChangesAsync();//commit the transaction
                return medicine.MedicineId;
            }
            return 0;
        }
        #endregion

        #region getmedicines
        public async Task<List<TbllMedicines>> GetMedicines()
        {
            if (db != null)
            {
                return await db.TbllMedicines.ToListAsync();
            }
            return null;



        }
        #endregion
        #region updatemedicine
        public async Task<TbllMedicines> UpdateMedicine(TbllMedicines staff)
        {
            if (db != null)
            {
                db.TbllMedicines.Update(staff);
                await db.SaveChangesAsync();
                return staff;
            }
            return null;
        }
        #endregion

        #region Get medicine By ID        
        public async Task<ActionResult<TbllMedicines>> GetMedicineById(int medicineId)
        {
            if (db != null)
            {
                TbllMedicines test = await db.TbllMedicines.FirstOrDefaultAsync(em => em.MedicineId == medicineId);
                return test;
            }
            return null;
        }
        #endregion
    }
}
