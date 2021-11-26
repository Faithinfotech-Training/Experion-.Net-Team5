using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Prescriptions
    {
        public Prescriptions()
        {
            MedicinesNavigation = new HashSet<Medicines>();
        }

        public int PrescriptionId { get; set; }
        public int? ConsultingId { get; set; }
        public int? TestId { get; set; }
        public string Medicines { get; set; }
        public string DoctorNotes { get; set; }
        public bool IsActive { get; set; }

        public virtual Consultings Consulting { get; set; }
        public virtual Tests Test { get; set; }
        public virtual ICollection<Medicines> MedicinesNavigation { get; set; }
    }
}
