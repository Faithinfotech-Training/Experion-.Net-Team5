using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Bills
    {
        public int BillId { get; set; }
        public int? PatientId { get; set; }
        public int? ConsultingId { get; set; }
        public int? MedicineId { get; set; }
        public decimal? ConsultingFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool IsActive { get; set; }

        public virtual Consultings Consulting { get; set; }
        public virtual Medicines Medicine { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
