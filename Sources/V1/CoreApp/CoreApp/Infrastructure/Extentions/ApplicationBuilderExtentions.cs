using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace CoreApp.Infrastructure.Extentions
{
    public static class ApplicationBuilderExtentions
    {
        /// <summary>
        /// Add excetion handling
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        /// <param name="env">Hosting environment</param>
        public static void UseExceptionHandler(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // TODO: Log error
            //app.UseExceptionHandler(handler => handler.Run(context => {
            //    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            //    if (exception == null)
            //        return Task.CompletedTask;

            //    try
            //    {
            //        logger.LogError(exception, message: "Error");
            //    }
            //    finally
            //    {
            //        //rethrow the exception to show the error page
            //        throw exception;
            //    }
            //}));
        }

        /// <summary>
        /// Add Mvc, Api map routes configuring 
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        public static void UseCoreAppMvc(this IApplicationBuilder app)
        {
            // MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "Areas",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Configure Static files
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        /// <param name="enableCache">Enable cache header</param>
        public static void UseCoreAppStaticFiles(this IApplicationBuilder app, bool enableCache)
        {
            if (enableCache)
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        // max-age=86400 => 1 day
                        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=86400");
                    }
                });
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
                    }
                });
            }
        }

        /// <summary>
        /// Configure enable access directory on browser
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        public static void UseCoreAppDirectoryBrowser(this IApplicationBuilder app)
        {
            // Set up custom content types - associating file extension to MIME type
            var provider = new FileExtensionContentTypeProvider();
            // Config mappings
            provider.Mappings[".xlsx"] = "application/x-msdownload";

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyFiles",
                ContentTypeProvider = provider
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyFiles"
            });
        }

        /// <summary>
        /// Configure default files to run when app start
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        public static void UserCoreAppDefaultFiles(this IApplicationBuilder app)
        {
            // Serve my app-specific default file, if present.
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("mydefault.html");
            app.UseDefaultFiles(options);
        }
    }
}
