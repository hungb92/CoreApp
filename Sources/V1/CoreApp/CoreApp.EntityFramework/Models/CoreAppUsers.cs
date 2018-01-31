using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUsers
    {
        public CoreAppUsers()
        {
            CoreAppUserRoles = new HashSet<CoreAppUserRoles>();
            CoreAppUserTokens = new HashSet<CoreAppUserTokens>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string SecurityStamp { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<CoreAppUserRoles> CoreAppUserRoles { get; set; }
        public ICollection<CoreAppUserTokens> CoreAppUserTokens { get; set; }
    }
}
