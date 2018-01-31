using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CoreApp.Repositories.UserService;
using CoreApp.Base.Repository;

namespace CoreApp.Configuration.DependencyInjection
{
    public class RepositoryModule : Autofac.Module
    {
        /// <summary>
        /// To configure DI for Repository module
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UserRep>().As<IUserRep>().InstancePerLifetimeScope();
        }
    }
}
