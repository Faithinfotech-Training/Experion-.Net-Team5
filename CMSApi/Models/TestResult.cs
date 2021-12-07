using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class TestResult
    {
        public int ResultId { get; set; }
        public int TestId { get; set; }
        public decimal Result { get; set; }

        public virtual Dtests Test { get; set; }
    }
}
