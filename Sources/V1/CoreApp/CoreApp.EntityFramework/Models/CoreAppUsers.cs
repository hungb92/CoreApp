using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUsers
    {
        public CoreAppUsers()
        {
            CoreAppUserClaims = new HashSet<CoreAppUserClaims>();
            CoreAppUserLogins = new HashSet<CoreAppUserLogins>();
            CoreAppUserRoles = new HashSet<CoreAppUserRoles>();
        }

        public long Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public ICollection<CoreAppUserClaims> CoreAppUserClaims { get; set; }
        public ICollection<CoreAppUserLogins> CoreAppUserLogins { get; set; }
        public ICollection<CoreAppUserRoles> CoreAppUserRoles { get; set; }
    }
}
