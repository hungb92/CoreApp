using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CoreApp.Data.Account;
using CoreApp.Infrastructure.Base.Data;

namespace CoreApp.Configuration.DependencyInjection
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<AccountDataService>().As<IAccountDataService>().InstancePerLifetimeScope();
        }
    }
}
