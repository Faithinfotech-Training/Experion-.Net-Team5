using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Consultings = new HashSet<Consultings>();
            Patients = new HashSet<Patients>();
            TblAppointment = new HashSet<TblAppointment>();
            TblLabReport = new HashSet<TblLabReport>();
            TblMedicines = new HashSet<TblMedicines>();
            TblObservation = new HashSet<TblObservation>();
            TblPatients = new HashSet<TblPatients>();
            TblPrescription = new HashSet<TblPrescription>();
            TbllAppointments = new HashSet<TbllAppointments>();
            TbllMedicines = new HashSet<TbllMedicines>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
        public string Contact { get; set; }
        public string Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Consultings> Consultings { get; set; }
        public virtual ICollection<Patients> Patients { get; set; }
        public virtual ICollection<TblAppointment> TblAppointment { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<TblMedicines> TblMedicines { get; set; }
        public virtual ICollection<TblObservation> TblObservation { get; set; }
        public virtual ICollection<TblPatients> TblPatients { get; set; }
        public virtual ICollection<TblPrescription> TblPrescription { get; set; }
        public virtual ICollection<TbllAppointments> TbllAppointments { get; set; }
        public virtual ICollection<TbllMedicines> TbllMedicines { get; set; }
    }
}
