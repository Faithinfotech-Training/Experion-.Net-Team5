using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Doctors = new HashSet<Doctors>();
            Staffs = new HashSet<Staffs>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
