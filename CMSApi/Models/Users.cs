using System;
using System.Collections.Generic;

namespace CMSApi.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
