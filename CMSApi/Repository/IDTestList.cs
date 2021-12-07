using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSApi.ViewModel;

namespace CMSApi.Repository
{
    public interface IDTestList
    {
        Task<List<PatientTestViewModel>> GetTestByPatientId(int id);
    }
}
