using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface ITestNameRepo
    {
        Task<List<TestNameViewModel>> GetTestById(int id);
    }
}
