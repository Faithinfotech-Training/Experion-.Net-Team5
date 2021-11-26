using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Staffs
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public decimal? Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Designations Designation { get; set; }
    }
}
