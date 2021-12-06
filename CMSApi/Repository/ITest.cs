using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface ITest
    {
        Task<List<Tests>> GetTestByPatientId(int id);

        Task<List<Staffs>> GetStaffbyId(int id);
        Task<int> AddTest(Tests test);

        Task UpdateTest(Tests test);

        Task<List<Tests>> GetTest();
    }
}
