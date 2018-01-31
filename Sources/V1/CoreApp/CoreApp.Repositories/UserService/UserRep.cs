using CoreApp.Base.Repository;
using CoreApp.EntityFramework.Models;
using System.Linq;

namespace CoreApp.Repositories.UserService
{
    public sealed class UserRep : BaseRepository<CoreAppUsers>, IUserRep
    {
        public UserRep(CoreAppContext context) : base(context)
        {
        }

        public CoreAppUsers ValidateSignIn(string userNameOrEmail, string passwordHash)
        {
            return Entities.SingleOrDefault(p => (p.UserName == userNameOrEmail || p.Email == userNameOrEmail) && p.PasswordHash == passwordHash);
        }
    }
}
