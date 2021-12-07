using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class PrescriptionViewModel
    {
        public int PrescriptionId { get; set; }
        public string DoctorNotes { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public bool? IsActive { get; set; }
    }
}
