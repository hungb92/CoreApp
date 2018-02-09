using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppRoles
    {
        public CoreAppRoles()
        {
            CoreAppRoleClaims = new HashSet<CoreAppRoleClaims>();
            CoreAppUserRoles = new HashSet<CoreAppUserRoles>();
        }

        public long Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<CoreAppRoleClaims> CoreAppRoleClaims { get; set; }
        public ICollection<CoreAppUserRoles> CoreAppUserRoles { get; set; }
    }
}
