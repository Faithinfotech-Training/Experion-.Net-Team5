using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblMedicines
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public decimal? Dosage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
