using CMSApi.Models;
using CMSApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface ILabReport
    {
        Task<List<LabReportViewModel>> GetLabReports();
        Task<List<LabReportViewModel>> GetLabReports(int id);
        Task<List<TblLabReport>> GetReport();

        Task<int> AddReport(TblLabReport model);
    }
}
