using CoreApp.Base.Service;
using CoreApp.EntityFramework.Models;

namespace CoreApp.Service.UserService
{
    public interface IUserService : IBaseService<CoreAppUsers>
    {
        CoreAppUsers ValidateSignIn(string userNameOrEmail, string password);
    }
}
