using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OtlobProject.Areas.Identity.Data;
using OtlobProject.Data;
using OtlobProject.Models;
using OtlobProject.Services;

namespace OtlobProject
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
            services.AddSession();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient(typeof(IService<Address>), typeof(AddressService));
            services.AddTransient(typeof(IService<Card>), typeof(CardService));
            services.AddTransient(typeof(IService<MealsInMenu>), typeof(MealsServices));
            services.AddTransient(typeof(IService<Order>), typeof(OrderService));
            services.AddTransient(typeof(IService<Restaurant>), typeof(ResautrantService));
            services.AddTransient(typeof(IService<Area>), typeof(AreaServices));
            services.AddHttpContextAccessor();

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
            app.UseSession();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapRazorPages();
            });
           

        }
    }
}
