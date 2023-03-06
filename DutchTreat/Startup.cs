using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
          
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
