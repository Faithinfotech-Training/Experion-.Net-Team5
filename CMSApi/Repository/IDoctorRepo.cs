using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
   public interface IDoctorRepo
    {
        //Asynchronous operation
        Task<List<Doctors>> GetDoctors();
       // Task<DoctorViewModel> GetDoctor(int id);

        //add doctor
        Task<int> AddDoctor(Doctors doc);

        //update doctor
        Task UpdateDoctor(Doctors doc);

        //get all doctors
        Task<List<DoctorViewModel>> GetAllDoctors();
        Task<List<Departments>> GetDepartments();

        Task<DoctorViewModel> GetDoctor(int id);
        Task<List<DoctorViewModel>> GetDeptDoctor(int id);

    }
}
