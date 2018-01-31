using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CoreApp.WebApi.Controllers;
using CoreApp.Base.Controllers;

namespace CoreApp.Configuration.DependencyInjection
{
    public class WebApiModule : Autofac.Module
    {
        /// <summary>
        /// To configure DI for WebApi module
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.RegisterGeneric(typeof(BaseApiController<>)).PropertiesAutowired();
            //builder.RegisterType<BaseAppController>().PropertiesAutowired();
        }
    }
}
