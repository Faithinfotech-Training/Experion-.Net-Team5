using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
   public interface IDtest
    {
        Task<int> AddTest(Dtests test);

        Task<List<Dtests>> GetTests();

        Task<List<Ntests>> GetTestName();
        Task<List<LabTestAppViewModel>> GetLabAppointmentByDate(DateTime date);

        Task<int> AddTestReport(TestResult test);

        Task<List<Dtests>> Gettest();

        Task<List<TestResult>> Getresult();
    }
}
