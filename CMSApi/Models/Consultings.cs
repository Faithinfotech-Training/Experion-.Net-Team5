using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Consultings
    {
        public Consultings()
        {
            Bills = new HashSet<Bills>();
            Prescriptions = new HashSet<Prescriptions>();
            TestBills = new HashSet<TestBills>();
            Tests = new HashSet<Tests>();
        }

        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int ConsultingId { get; set; }
        public DateTime? ConsultingDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
        public virtual ICollection<TestBills> TestBills { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
