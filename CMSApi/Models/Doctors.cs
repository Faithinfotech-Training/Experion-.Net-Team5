using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Consultings = new HashSet<Consultings>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
        public string Contact { get; set; }
        public string Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Consultings> Consultings { get; set; }
    }
}
