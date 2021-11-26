using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Designations
    {
        public Designations()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
