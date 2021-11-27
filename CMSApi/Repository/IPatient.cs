using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IPatient
    {
        //get all patients
        Task<List<Patients>> GetAllPatients();

        //get patient by Id


        //add patient
        Task<Patients> AddPatients(Patients patient);

        //update patient
        Task<Patients> UpdatePatients(Patients patient);
    }
}
