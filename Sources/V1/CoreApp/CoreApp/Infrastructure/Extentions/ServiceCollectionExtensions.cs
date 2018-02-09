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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="applicationContainer"></param>
        /// <returns></returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IContainer applicationContainer)
        {
            services.AddMvc();

            // DB Context
            var connection = @"Server=I3-PC-NEWMEM;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CoreAppContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<CoreAppContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/app/account/login");

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/app/account/login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/app/account/logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/app/account/accessdenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

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
