using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IAppointmentRepository
    {
        //add appointment
        #region add appointment
        Task<int> AddAppointment(TbllAppointments appointment);
        #endregion

        //update appointment
        #region update appointment
        Task UpdateAppointment(TbllAppointments appointment);
        #endregion

        //get appointment
        #region get appointment
        Task<List<AppointmentViewModel>> GetAppointment();
        #endregion

        //get appointment by id
        #region get appointment by id
        Task<AppointmentViewModel> GetAppointmentById(int id);
        #endregion

        Task<List<AppointmentViewModel>> GetAppointmentByDoctorIdAndDate(int id, DateTime date);
    }
}
