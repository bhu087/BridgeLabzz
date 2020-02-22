/////------------------------------------------------------------------------
////<copyright file="Startup.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// This is the Startup program
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.     
        /// </summary>
        /// <param name="services">service collection interface</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Hosting Environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
