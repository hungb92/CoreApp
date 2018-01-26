using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CoreApp.Service.Account;
using CoreApp.Infrastructure.Base.Service;
using CoreApp.Infrastructure.Base.Data;

namespace CoreApp.Configuration.DependencyInjection
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
            builder.RegisterType<AccountBussinessService>().As<IAccountBussinessService>().InstancePerLifetimeScope();
        }
    }
}
