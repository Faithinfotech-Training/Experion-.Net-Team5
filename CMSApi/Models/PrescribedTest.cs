using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class PrescribedTest
    {
        public int PrescribedTestId { get; set; }
        public string PrescribedTestName { get; set; }
        public bool? IsActive { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual TblPrescription Prescription { get; set; }
    }
}
