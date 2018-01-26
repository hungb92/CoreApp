using CoreApp.EntityFramework.Models;
using CoreApp.Infrastructure.Base.Data;
using CoreApp.Infrastructure.Base.Service;

namespace CoreApp.Service.Account
{
    public sealed class AccountBussinessService : BaseService<Blog>, IAccountBussinessService
    {
        public AccountBussinessService(IBaseRepository<Blog> rep) : base(rep)
        {
        }
    }
}
