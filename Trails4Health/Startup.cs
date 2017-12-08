using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trails4Health.Data;
using Trails4Health.Models;
using Trails4Health.Services;

namespace Trails4Health
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<LoginsApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // popular B:D.
           // SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
