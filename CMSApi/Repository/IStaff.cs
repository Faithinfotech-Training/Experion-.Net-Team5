using CMSApi.Models;
using CMSApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
     public interface IStaff
    {
        //--view staffs

        Task<List<Staffs>> GetStaff();
        //get departments
        Task<List<Departments>> GetDepartment();
        //get Designation
        Task<List<Designations>> GetDesignation();

        //--- add Staff ---//
        Task<Staffs> Addstaff(Staffs staff);

        //--- update staff --//

        Task<Staffs> UpdateStaff(Staffs staff);
        //GetallStaffs

        Task<StaffViewModel> GetStaffbyId(int id);


    }
}
