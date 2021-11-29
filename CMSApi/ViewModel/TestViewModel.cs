using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class TestViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime ConsultingDate { get; set; }
        public string DoctorNotes { get; set; }
        public string MedicineName { get; set; }
        public int? Quantity { get; set; }
        public string TestNames { get; set; }
        public decimal? Result { get; set; }
    }
}
