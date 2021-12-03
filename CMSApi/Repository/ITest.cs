using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface ITest
    {
        Task<List<TblTest>> GetTestByReportId(int id);

        Task<List<Staffs>> GetStaffbyId(int id);
        Task<int> AddTest(TblTest test);

        Task UpdateTest(TblTest prescription);
    }
}
