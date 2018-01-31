using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreApp.Areas.App.Models;
using CoreApp.Configuration.DependencyInjection;
using CoreApp.EntityFramework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IContainer applicationContainer)
        {
            services.AddMvc();

            // DB Context
            var connection = @"Server=I3-PC-NEWMEM;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CoreAppContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CoreAppContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/app/account/login");

            // Autofac Dependency Injection
            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<WebApiModule>();
            builder.Populate(services);
            applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }
    }
}
