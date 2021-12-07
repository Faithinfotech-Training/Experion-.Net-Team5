using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IPrescriptionRepo
    {
        Task<List<TbllPrescription>> GetPrescriptions();
        Task<TbllPrescription> AddPrescriptions(TbllPrescription staff);
        //Task UpdatePrescription(TbllPrescription prescription);

        Task<TbllPrescription> UpdatePrescription(TbllPrescription staff);

        #region get payment bill by id
        Task<List<PrescriptionViewModel>> GetPrescriptionById(int id);
        #endregion

    }
}
