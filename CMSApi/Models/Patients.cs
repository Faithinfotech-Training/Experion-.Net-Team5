using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Bills = new HashSet<Bills>();
            Consultings = new HashSet<Consultings>();
            TblAppointment = new HashSet<TblAppointment>();
            TblLabReport = new HashSet<TblLabReport>();
            TblMedicines = new HashSet<TblMedicines>();
            TblPaymentBill = new HashSet<TblPaymentBill>();
            TblPrescription = new HashSet<TblPrescription>();
            Tests = new HashSet<Tests>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public int? Age { get; set; }
        public string BloodGroup { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Consultings> Consultings { get; set; }
        public virtual ICollection<TblAppointment> TblAppointment { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<TblMedicines> TblMedicines { get; set; }
        public virtual ICollection<TblPaymentBill> TblPaymentBill { get; set; }
        public virtual ICollection<TblPrescription> TblPrescription { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
