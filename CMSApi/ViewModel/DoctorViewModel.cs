using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
        public string Contact { get; set; }
        public string Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
