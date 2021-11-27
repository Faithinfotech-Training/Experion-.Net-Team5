using CMSApi.Models;
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

        //add doctor
        Task<int> AddDoctor(Doctors doc);

        //update doctor
        Task UpdateDoctor(Doctors doc);
    }
}
