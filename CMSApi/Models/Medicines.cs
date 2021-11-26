using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Medicines
    {
        public Medicines()
        {
            Bills = new HashSet<Bills>();
        }

        public int MedicineId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Amount { get; set; }
        public bool IsActive { get; set; }

        public virtual Prescriptions Prescription { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
    }
}
