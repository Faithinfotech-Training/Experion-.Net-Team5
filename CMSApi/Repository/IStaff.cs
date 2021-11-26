using CMSApi.Models;
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

        //--- add Staff ---//
        Task<Staffs> Addstaff(Staffs staff);

        //--- update staff --//

        Task<Staffs> UpdateStaff(Staffs staff);


    }
}
