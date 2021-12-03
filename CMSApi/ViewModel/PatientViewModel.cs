using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public string Address { get; set; }
        public int Contact { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; }

    }
}
