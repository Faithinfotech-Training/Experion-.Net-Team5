using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class TestNameViewModel
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public int? TestNameId { get; set; }
        public DateTime TestDate { get; set; }
        public bool? IsActive { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public int NtestId { get; set; }
        public decimal Result { get; set; }
    }
}
