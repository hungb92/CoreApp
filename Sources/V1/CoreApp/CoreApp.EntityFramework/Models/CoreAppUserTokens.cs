using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppUserTokens
    {
        public long UserId { get; set; }
        public long LoginProviderId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public CoreAppLoginProviders LoginProvider { get; set; }
        public CoreAppUsers User { get; set; }
    }
}
