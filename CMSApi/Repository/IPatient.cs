using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IPatient
    {
        //get patient
      
        Task<List<TblPatients>> GetPatients();
       



        //add patient
        Task<TblPatients> AddPatients(TblPatients patient);



        //update patient
        Task<TblPatients> UpdatePatients(TblPatients patient);
     
        Task<ActionResult<TblPatients>> GetPatientById(int patientId);
      






    }
}
