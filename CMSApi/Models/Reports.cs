using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Reports
    {
        public int ReportId { get; set; }
        public int? TestId { get; set; }
        public int? ResultId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? ReportDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Results Result { get; set; }
        public virtual test Test { get; set; }
    }
}
