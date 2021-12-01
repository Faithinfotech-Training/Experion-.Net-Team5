using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Tests
    {
        public Tests()
        {
            Prescriptions = new HashSet<Prescriptions>();
            TestBills = new HashSet<TestBills>();
        }

        public int TestId { get; set; }
        public int? PatientId { get; set; }
        public int? ConsultingId { get; set; }
        public DateTime? TestDate { get; set; }
        public string TestNames { get; set; }
        public bool IsActive { get; set; }
        public int? NormalRange { get; set; }
        public int? TestResult { get; set; }

        public virtual Consultings Consulting { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
        public virtual ICollection<TestBills> TestBills { get; set; }
    }
}
