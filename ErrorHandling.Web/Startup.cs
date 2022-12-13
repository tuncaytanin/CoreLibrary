using ErrorHandling.Web.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Web
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
            services.AddControllersWithViews();
            services.AddMvc(options => {
                options.Filters.Add(new CustomHandleExceptionFilterAttribute() { ErroPage="hata1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             * 
             *  Request  ----- [DeveloperExceptionPage]-----[ExceptionHandler]--------[UseStatusCodePages] ------> Response
             */
            if (env.IsDevelopment())
            {
                //1.Yol
                app.UseDeveloperExceptionPage();

                //2.Yol
                //    app.UseStatusCodePages("text/plain", " Bir hata var durum kodu : {0}");

                //3.Yol
                app.UseStatusCodePages(async context =>
                {
                    context.HttpContext.Response.ContentType = "text/plain";
                    await context.HttpContext.Response.WriteAsync($"Bir Hatamiz var. Durum Kodu: {context.HttpContext.Response.StatusCode.ToString()}");
                });
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseExceptionHandler(context =>
            //{
            //    context.Run(async page =>
            //    {
            //        page.Response.StatusCode = 500;
            //        page.Response.ContentType = "txt/html";
            //        await page.Response.WriteAsync(@$"<html> 
            //                                            <head> 
            //                                                    <h1> Hata : {page.Response.StatusCode}</h1> 
            //                                            </head> 
            //                                          </html>");
            //    });
            //});
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
