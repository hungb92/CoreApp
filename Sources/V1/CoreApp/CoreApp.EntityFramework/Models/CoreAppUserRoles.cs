using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUserRoles
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public CoreAppRoles Role { get; set; }
        public CoreAppUsers User { get; set; }
    }
}
