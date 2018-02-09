using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppRoleClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public long RoleId { get; set; }

        public CoreAppRoles Role { get; set; }
    }
}
