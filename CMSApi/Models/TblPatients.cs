using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblPatients
    {
        public TblPatients()
        {
            TbllAppointments = new HashSet<TbllAppointments>();
            TbllMedicines = new HashSet<TbllMedicines>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public decimal? Contact { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string BloodGroup { get; set; }
        public bool? IsActive { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual ICollection<TbllAppointments> TbllAppointments { get; set; }
        public virtual ICollection<TbllMedicines> TbllMedicines { get; set; }
    }
}
