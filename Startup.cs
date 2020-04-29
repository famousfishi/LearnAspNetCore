using LearnAspCoreBest.Data;
using LearnAspCoreBest.InterfaceRepositories;
using LearnAspCoreBest.MockData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LearnAspCoreBest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register appdbcontext for Database
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbConnection")));
            //adding MVC to your app
            services.AddMvc();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //services.AddSingleton<ILeadRepository, MockLeadRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
                logger.LogInformation("testing on developer exception page");
            }
            //else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            //{
            //    app.UseExceptionHandler("/Error");
            //}


            //app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseFileServer();

            //app.UseMvcWithDefaultRoute();

            //conventional routing
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //    await context.Response.WriteAsync("Hosting Environment :" + env.EnvironmentName);
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //    //await context.Response.WriteAsync(_configuration["MyKey"]);
            //});
        }
    }
}