using CMSApi.Models;
using CMSApi.ViewModel;
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

        #region
        public async Task<List<Departments>> GetDepartments()
        {

            if (db != null)
            {
                return await db.Departments.ToListAsync();
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
        public async Task<List<DoctorViewModel>> GetAllDoctors()
        {
            if (db != null)
            {
                //linq
                //join doctors and department
                return await (from p in db.Doctors
                              from c in db.Departments
                              where p.DepartmentId == c.DepartmentId
                              select new DoctorViewModel
                              {
                                  DoctorId = p.DoctorId,
                                  DoctorName = p.DoctorName,
                                  Specialization = p.Specialization,
                                  Contact = p.Contact,
                                  Experience = p.Experience,
                                  JoiningDate = p.JoiningDate,
                                  IsActive = p.IsActive,
                                  DepartmentName = c.DepartmentName
                              }
                ).ToListAsync();
            }
            return null;
        }
        #region GetEmployeeByID
        public async Task<DoctorViewModel> GetDoctor(int id)
        {
            if (db != null)
            {
                //LINQ
                return await (from p in db.Doctors
                              from c in db.Departments
                              where p.DoctorId == id
                              select new DoctorViewModel
                              {
                                  DoctorId = p.DoctorId,
                                  DoctorName = p.DoctorName,
                                  Specialization = p.Specialization,
                                  Contact = p.Contact,
                                  Experience = p.Experience,
                                  JoiningDate = p.JoiningDate,
                                  IsActive = p.IsActive,
                                  DepartmentId = c.DepartmentId,

                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        #region GetDoctorsByDept
        public async Task<List<DoctorViewModel>> GetDeptDoctor(int id)
        {
            if (db != null)
            {
                //LINQ
                return await (from c in db.Departments
                              from p in db.Doctors
                              where c.DepartmentId == id && p.DepartmentId == c.DepartmentId
                              select new DoctorViewModel
                              {
                                  DepartmentId = c.DepartmentId,
                                  DepartmentName=c.DepartmentName,
                                  IsActive=c.IsActive,
                                  DoctorId = p.DoctorId,
                                  DoctorName = p.DoctorName



                              }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
