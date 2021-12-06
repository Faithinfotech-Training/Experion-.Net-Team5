using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Results
    {
        public Results()
        {
            Reports = new HashSet<Reports>();
        }

        public int ResultId { get; set; }
        public int? TestId { get; set; }
        public decimal? Result { get; set; }
        public bool IsActive { get; set; }

        public virtual Tests Test { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
    }
}
