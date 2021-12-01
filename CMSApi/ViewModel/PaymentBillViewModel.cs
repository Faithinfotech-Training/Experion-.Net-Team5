using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.ViewModel
{
    public class PaymentBillViewModel
    {
        public int BillId { get; set; }
        public int? BillNumber { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsActive { get; set; }
        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        public int Contact { get; set; }

    }
}
