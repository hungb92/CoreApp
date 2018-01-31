using CoreApp.Base.Repository;
using CoreApp.Base.Service;
using CoreApp.EntityFramework.Models;
using CoreApp.Repositories.UserService;
using System.Linq;

namespace CoreApp.Service.UserService
{
    public sealed class UserService : BaseService<CoreAppUsers>, IUserService
    {
        private readonly IUserRep _rep;
        public UserService(IUserRep rep) : base(rep)
        {
            _rep = rep;
        }

        public CoreAppUsers ValidateSignIn(string userNameOrEmail, string password)
        {
            return _rep.ValidateSignIn(userNameOrEmail, password);
        }
    }
}
