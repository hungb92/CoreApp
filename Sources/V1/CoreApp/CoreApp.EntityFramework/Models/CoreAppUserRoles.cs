using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUserRoles
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public CoreAppRoles Role { get; set; }
        public CoreAppUsers User { get; set; }
    }
}
