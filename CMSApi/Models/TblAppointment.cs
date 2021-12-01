using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblAppointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
