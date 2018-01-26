using CoreApp.EntityFramework.Models;
using CoreApp.Infrastructure.Base.Data;

namespace CoreApp.Data.Account
{
    public interface IAccountDataService : IBaseRepository<Blog>
    {
    }
}
