using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Dtests
    {
        public int TestId { get; set; }
        public int? TestNameId { get; set; }
        public DateTime? TestDate { get; set; }
        public bool? IsActive { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual TblPatients Patient { get; set; }
        public virtual Ntests TestName { get; set; }
    }
}
