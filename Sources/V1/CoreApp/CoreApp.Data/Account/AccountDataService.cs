using CoreApp.EntityFramework.Models;
using CoreApp.Infrastructure.Base.Data;

namespace CoreApp.Data.Account
{
    public sealed class AccountDataService : BaseRepository<Blog>, IAccountDataService
    {
        public AccountDataService(CoreAppContext context) : base(context)
        {
        }
    }
}
