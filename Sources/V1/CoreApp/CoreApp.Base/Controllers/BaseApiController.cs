using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Base.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreApp.Base.Controllers
{
    [Route("api/[controller]")]
    public partial class BaseApiController<T> : Controller where T : class
    {
        #region Fields

        protected readonly IBaseService<T> _service;
        protected readonly ILogger<BaseApiController<T>> _logger;
        #endregion

        #region Contructors

        public BaseApiController(IBaseService<T> service, ILogger<BaseApiController<T>> logger)
        {
            _service = service;
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all
        /// URL: api/[controller]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            return _service.GetAll();
        }

        

        #endregion

        #region Properties

        #endregion
    }
}
