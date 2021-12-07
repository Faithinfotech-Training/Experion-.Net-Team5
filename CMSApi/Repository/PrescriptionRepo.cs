using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class PrescriptionRepo : IPrescriptionRepo
    {
        //database/json
        DBClinicContext db;

        //Constructor dependency injection
        public PrescriptionRepo(DBClinicContext _db)
        {
            db = _db;
        }

        public async Task<List<TbllPrescription>> GetPrescriptions()
        {
            if (db != null)
            {
                return await db.TbllPrescription.ToListAsync();
            }
            return null;



        }


        public async Task<TbllPrescription> AddPrescriptions(TbllPrescription staff)
        {
            //--- member function to add department ---//
            if (db != null)
            {
                await db.TbllPrescription.AddAsync(staff);
                await db.SaveChangesAsync();
                return staff;
            }
            return null;

        }





        public async Task<TbllPrescription> UpdatePrescription(TbllPrescription staff)
        {
            if (db != null)
            {
                db.TbllPrescription.Update(staff);
                await db.SaveChangesAsync();
                return staff;
            }
            return null;
        }


        #region get payment bill by id
        public async Task<List<PrescriptionViewModel>> GetPrescriptionById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient
                return await (from b in db.TbllPrescription
                              from p in db.TblPatients
                              where b.PatientId == id && b.PatientId == p.PatientId
                              select new PrescriptionViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = p.PatientName,
                                  DoctorNotes = b.DoctorNotes,
                                  PrescriptionDate = b.PrescriptionDate,
                                  IsActive = b.IsActive
                              }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
