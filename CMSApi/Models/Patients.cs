﻿using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Consultings = new HashSet<Consultings>();
            TblLabReport = new HashSet<TblLabReport>();
            Tests = new HashSet<Tests>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Consultings> Consultings { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
