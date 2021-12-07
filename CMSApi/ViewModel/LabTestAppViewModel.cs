using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class LabTestAppViewModel
    {
        public int TestId { get; set; }
        public int? TestNameId { get; set; }
        public DateTime TestDate { get; set; }
        public bool IsActive { get; set; }
        public int NTestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }



        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
