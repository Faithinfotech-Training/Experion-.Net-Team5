using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
