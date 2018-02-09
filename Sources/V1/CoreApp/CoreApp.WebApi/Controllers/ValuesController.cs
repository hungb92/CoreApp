using CoreApp.Base.Controllers;
using Microsoft.Extensions.Logging;

namespace CoreApp.WebApi.Controllers
{

    public class ValuesController : BaseApiController<CoreAppUsers>
    {
        #region Fields

        #endregion

        #region Contructors

        public ValuesController(IUserService service, ILogger<BaseApiController<CoreAppUsers>> logger) : base(service, logger)
        {
        }

        #endregion

        #region Methods



        #endregion
    }
}
