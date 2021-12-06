using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TbllPrescription
    {
        public int PrescriptionId { get; set; }
        public string DoctorNotes { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual TblPatients Patient { get; set; }
    }
}
