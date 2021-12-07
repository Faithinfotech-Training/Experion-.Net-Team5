using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public bool? IsActive { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public decimal Contact { get; set; }
    }
}
