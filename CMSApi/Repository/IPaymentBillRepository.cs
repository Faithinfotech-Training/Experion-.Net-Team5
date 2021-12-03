using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IPaymentBillRepository
    {
        //Generate Payment Bill

        #region get payment bill details
        //get payment bill details
        Task<List<PaymentBillViewModel>> GetPaymentBill();
        #endregion

        #region add payment bill details
        //add payment bill details
        Task<int> AddPaymentBill(TblPaymentBill bill);
        #endregion

        #region update payment bill details
        //update payment bill details
        Task UpdatePaymentBill(TblPaymentBill bill);
        #endregion

        #region get payment bill by id
        Task<PaymentBillViewModel> GetPaymentBillById(int id);
        #endregion
    }
}
