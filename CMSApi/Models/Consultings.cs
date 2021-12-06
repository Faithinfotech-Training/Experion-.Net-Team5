using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Consultings
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int ConsultingId { get; set; }
        public DateTime ConsultingDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
