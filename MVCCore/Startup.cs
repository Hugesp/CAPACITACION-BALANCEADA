using BussinesLogic;
using BussinesLogic.Interfaces;
using BussinesLogic.Servicios;
using Entities.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore
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
            //Inicio BD --Configuración cadena de conexión
            services.AddDbContext<DemoContext>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("DemoConnection")));

            // Inyeccion de dependencias de Bussines Logic
            services.AddScoped(typeof(IService<>), typeof(Service<>));//Siempre que encuentre una interface de este tipo IService, la vas a inicializar con esta clase Service
            // Inyeccion de dependencias de DataAccess
            services.AddDaServices();//Inicializa la interface del acceso a datos

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Clientes}/{action=Index}/{id?}");
            });
        }
    }
}
