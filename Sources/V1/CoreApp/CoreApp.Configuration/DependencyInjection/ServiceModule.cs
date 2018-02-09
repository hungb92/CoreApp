using Autofac;
using CoreApp.Base.Service;
using CoreApp.Service.EmailSenderService;

namespace CoreApp.Configuration.DependencyInjection
{
    public class ServiceModule : Autofac.Module
    {
        /// <summary>
        /// To configure DI for Service module
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
            //builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
        }
    }
}
