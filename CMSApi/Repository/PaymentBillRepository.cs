using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class PaymentBillRepository : IPaymentBillRepository
    {
        //database/json
        DBClinicContext db;

        //Constructor dependency injection
        public PaymentBillRepository(DBClinicContext _db)
        {
            db = _db;
        }

        //Generate Payment Bill 

        #region add payment bill details
        //Add payment bill details
        public async Task<int> AddPaymentBill(TblPaymentBill bill)
        {
            if (db != null)
            {
                await db.TblPaymentBill.AddAsync(bill);
                await db.SaveChangesAsync();//commit the transaction
                return bill.BillId;
            }
            return 0;
        }
        #endregion

        #region get payment bill details
        //get payment bill details
        public async Task<List<PaymentBillViewModel>> GetPaymentBill()
        {
            if (db != null)
            {
                //LINQ
                return await (from b in db.TblPaymentBill
                              from p in db.Patients
                              where b.PatientId == p.PatientId
                              select new PaymentBillViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = p.PatientName,
                                  BillId = b.BillId,
                                  
                                  BillDate = b.BillDate,
                                  Amount = b.Amount,
                                  IsActive = b.IsActive
                              }
                             ).ToListAsync();
            }
            return null;
        }

        #endregion

        #region update payment bill details
        //update payment bill details
        public async Task UpdatePaymentBill(TblPaymentBill bill)
        {
            if (db != null)
            {
                db.TblPaymentBill.Update(bill);
                await db.SaveChangesAsync();//commit the transaction

            }
        }
        #endregion

        #region get payment bill by id
        public async Task<PaymentBillViewModel> GetPaymentBillById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient
                return await (from b in db.TblPaymentBill
                              from p in db.Patients
                              where b.BillId == id && b.PatientId == p.PatientId
                              select new PaymentBillViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = p.PatientName,
                                  Contact = p.Contact,
                                  BillId = b.BillId,
                                  
                                  BillDate = b.BillDate,
                                  Amount = b.Amount,
                                  IsActive = b.IsActive
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
    }
}
    

