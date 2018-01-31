using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Base.Controllers;
using CoreApp.EntityFramework.Models;
using CoreApp.Service.UserService;
using Microsoft.AspNetCore.Mvc;
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
