using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppContext
    {
        public CoreAppContext(DbContextOptions<CoreAppContext> options) : base(options)
        {
            InitConfiguration();
        }

        private void InitConfiguration()
        {
            // TODO
        }
    }
}
