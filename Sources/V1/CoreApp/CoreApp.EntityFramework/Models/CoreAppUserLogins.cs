using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public long UserId { get; set; }

        public CoreAppUsers User { get; set; }
    }
}
