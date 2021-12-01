using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblLabReport
    {
        public TblLabReport()
        {
            TblTest = new HashSet<TblTest>();
        }

        public int ReportId { get; set; }
        public int? ReportNumber { get; set; }
        public DateTime? ReportDate { get; set; }
        public string ReportNotes { get; set; }
        public int? PatientId { get; set; }
        public bool? IsActive { get; set; }
        public int? StaffId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual ICollection<TblTest> TblTest { get; set; }
    }
}
