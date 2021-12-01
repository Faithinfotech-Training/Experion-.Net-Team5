using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblPrescription
    {
        public TblPrescription()
        {
            PrescribedTest = new HashSet<PrescribedTest>();
        }

        public int PrescriptionId { get; set; }
        public int? PrescriptionNumber { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public bool? IsActive { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<PrescribedTest> PrescribedTest { get; set; }
    }
}
