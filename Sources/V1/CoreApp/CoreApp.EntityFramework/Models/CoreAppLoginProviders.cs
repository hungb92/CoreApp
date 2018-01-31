using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppLoginProviders
    {
        public CoreAppLoginProviders()
        {
            CoreAppUserTokens = new HashSet<CoreAppUserTokens>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<CoreAppUserTokens> CoreAppUserTokens { get; set; }
    }
}
