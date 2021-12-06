using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TblPaymentBill
    {
        public int BillId { get; set; }
        public DateTime? BillDate { get; set; }
        public int? Amount { get; set; }
        public bool? IsActive { get; set; }
        public int? PatientId { get; set; }

        public virtual TblPatients Patient { get; set; }
    }
}
