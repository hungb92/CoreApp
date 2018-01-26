using System;
using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public partial class Blog
    {
        public Blog()
        {
        }

        public long Id { get; set; }
        public string Url { get; set; }
    }
}
