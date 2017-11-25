using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trails4Health.Models;
using Microsoft.EntityFrameworkCore;

namespace Trails4Health
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  *** se quiser mudar repositorio...
            //- assim não preciso de mudar mais nada que nao seja FakeProductRepository
            // services.AddTransient<ITrails4HealthRepository, FakeProductRepository>(); // mudado!!

            /* configurar a app para usar a ConnectionStringTrails4Health e ligar á B.D.*/
            services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer
              (
                  // vou por nome da string connection do appsettings.jason
                  Configuration.GetConnectionString("ConnectionStringTrails4Health")
              )
          );
            /* quando são criados os componentes que usam ITrails4HealthRepository (no momento apenas Trilhos(controler)) 
               recebem um objecto EFTrails4HealthRepository, este objecto providencia aos componentes acesso á B.D. */
            services.AddTransient<ITrails4HealthRepository, EFTrails4HealthRepository>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // popular B:D.
            SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
