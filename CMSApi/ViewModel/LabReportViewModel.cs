using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class LabReportViewModel
    {
        public int ReportId { get; set; }
        public int? ReportNumber { get; set; }
        public DateTime? ReportDate { get; set; }
        public string ReportNotes { get; set; }
        public int? PatientId { get; set; }
        public bool? IsActive { get; set; }
        public int? StaffId { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string StaffName { get; set; }
    }
}
