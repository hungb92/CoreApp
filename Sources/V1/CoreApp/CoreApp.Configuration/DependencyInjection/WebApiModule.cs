using Autofac;

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
