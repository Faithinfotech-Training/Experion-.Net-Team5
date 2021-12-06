using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public string TestResult { get; set; }
        public int? StaffId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime TestDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
    }
}
