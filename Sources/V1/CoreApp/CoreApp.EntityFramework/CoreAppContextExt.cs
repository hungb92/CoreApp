using Microsoft.EntityFrameworkCore;

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
