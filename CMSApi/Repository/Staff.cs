using CMSApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class Staff : IStaff
    {
        DBClinicContext _db;
        public Staff(DBClinicContext db)
        {
            _db = db;
        }
        //view staff
        public async Task<List<Staffs>> GetStaff()
        {
            if (_db != null)
            {
                return await _db.Staffs.ToListAsync();
            }
            return null;



        }
        //add Staff
        #region
        public async Task<Staffs> Addstaff(Staffs staff)
        {
            //--- member function to add department ---//
            if (_db != null)
            {
                await _db.Staffs.AddAsync(staff);
                await _db.SaveChangesAsync();
                return staff;
            }
            return null;

        }

        #endregion

        

       

       
        //update staff
        public async Task<Staffs> UpdateStaff(Staffs staff)
        {
            if (_db != null)
            {
                _db.Staffs.Update(staff);
                await _db.SaveChangesAsync();
                return staff;
            }
            return null;
        }
        //--- member function to add values to room table ---//


       






    }
}


