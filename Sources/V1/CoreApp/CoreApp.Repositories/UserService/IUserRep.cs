using CoreApp.Base.Repository;
using CoreApp.EntityFramework.Models;

namespace CoreApp.Repositories.UserService
{
    public interface IUserRep : IBaseRepository<CoreAppUsers>
    {
        CoreAppUsers ValidateSignIn(string userNameOrEmail, string passwordHash);
    }
}
