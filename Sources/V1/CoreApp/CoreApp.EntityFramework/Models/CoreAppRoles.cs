using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppRoles
    {
        public CoreAppRoles()
        {
            CoreAppUserRoles = new HashSet<CoreAppUserRoles>();
        }

        public long Id { get; set; }
        public long ParrentId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<CoreAppUserRoles> CoreAppUserRoles { get; set; }
    }
}
