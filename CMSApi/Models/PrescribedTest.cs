using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class PrescribedTest
    {
        public int PrescribedTestId { get; set; }
        public string PrescribedTestName { get; set; }
        public bool? IsActive { get; set; }
        public int? TestId { get; set; }
        public int? PatientId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Tests Test { get; set; }
    }
}
