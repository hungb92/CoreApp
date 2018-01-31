using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Base.Controllers
{
    [Authorize]
    [Area("App")]
    public partial class BaseAppController : Controller
    {
        #region Fields

        protected readonly ILogger<BaseAppController> _logger;

        #endregion

        #region Contructors

        public BaseAppController(ILogger<BaseAppController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion
    }
}
