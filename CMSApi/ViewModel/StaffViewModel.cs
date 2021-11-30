using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class StaffViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public decimal? Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
    }
}
