using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TestBills
    {
        public int TestBillId { get; set; }
        public int? ConsultingId { get; set; }
        public int? TestId { get; set; }
        public decimal? TestAmount { get; set; }
        public bool IsActive { get; set; }

        public virtual Consultings Consulting { get; set; }
        public virtual Tests Test { get; set; }
    }
}
