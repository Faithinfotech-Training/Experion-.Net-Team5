using CMSApi.Models;
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
    }
}
