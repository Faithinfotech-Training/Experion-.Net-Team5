using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class Staff : IStaff
    {
        private DBClinicContext _db;
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
        #region Add Staff
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



        #region GetAllStaff
        public async Task<StaffViewModel> GetStaffbyId(int id)
        {
            if (_db != null)
            {
                return await (from c in _db.Departments
                              join s in _db.Staffs
                              on c.DepartmentId equals s.DepartmentId
                              join d in _db.Designations
                              on s.DesignationId equals d.DesignationId
                              where s.StaffId == id
                              select new StaffViewModel
                              {
                                  StaffId = s.StaffId,
                                  StaffName = s.StaffName,
                                  DepartmentId = c.DepartmentId,
                                  JoiningDate = s.JoiningDate,
                                  Experience = s.Experience,
                                  IsActive=s.IsActive,
                                  Designation = d.Designation,
                                  DepartmentName = c.DepartmentName,
                                  DesignationId=d.DesignationId
                                  
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        //get Department
        public async Task<List<Departments>> GetDepartment()
        {
            if (_db != null)
            {
                return await _db.Departments.ToListAsync();
            }
            return null;



        }

        //get Designation
        public async Task<List<Designations>> GetDesignation()
        {
            if (_db != null)
            {
                return await _db.Designations.ToListAsync();
            }
            return null;



        }






    }
}


