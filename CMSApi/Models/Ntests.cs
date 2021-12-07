using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Ntests
    {
        public Ntests()
        {
            Dtests = new HashSet<Dtests>();
        }

        public int NtestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }

        public virtual ICollection<Dtests> Dtests { get; set; }
    }
}
