using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface ITest
    {
        Task<List<test>> GetTestByPatientId(int id);

        Task<List<Staffs>> GetStaffbyId(int id);
        Task<int> AddTest(test test);

        Task UpdateTest(test test);

        Task<List<test>> GetTest();
    }
}
