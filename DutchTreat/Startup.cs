using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DutchTreat
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>();

            services.AddTransient<DutchSeeder>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IMailService, NullMailService>(); //buraya ekledikten sonra controllera enhjecte edecegiz  

            services.AddScoped<IDutchRepository, DutchRepository>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //orders loopa giriyordu ve listelenmiyordu include etsek de o yüzden newtonsoft for mvc indirip bunu ekledik.
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            if (env.IsDevelopment()) //IsEnvironment("Development")
            {
                app.UseDeveloperExceptionPage();
                //hata sayfasý
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

#endif
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //});

            //app.UseDefaultFiles(); 
            //middlewareler birbirleri ile baglantilidir. buradaki siralamayi degistirmek, calismayi etkiler. cünkü ikinci sirada varsayilan url degismis olur fakat dinleyicisi bulunmaz. yani calismaz. bu sirada olmalidir.
            app.UseStaticFiles();
            //web sunucumuza bir seyler yaptýrmak istedik.
            //static dosyalari hizmetine ekle.
            //fakat bunun calismasi icin static dosyalari wwwroot klasoru icine yuklemeliyiz.

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();

                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                new { controller = "app", action = "Index" });
            });
        }
    }
}
