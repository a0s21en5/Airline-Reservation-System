using Airline_Reservation_System.Context;
using Airline_Reservation_System.Repository;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Reservation_System
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
            string LocalSQlConnectionString = "Server=DESKTOP-J2MAC17;Database=AirlineReservationSystem;Trusted_Connection=True";
            services.AddControllersWithViews();
            services.AddScoped<IAdminService,AdminService>();
            services.AddScoped<IAdminRepository,AdminRepository>();
            services.AddScoped<IUserService ,UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<AirlineReservationSystemContextDb>(A=>A.UseSqlServer(LocalSQlConnectionString));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=GetAllUser}/{id?}");
            });
        }
    }
}