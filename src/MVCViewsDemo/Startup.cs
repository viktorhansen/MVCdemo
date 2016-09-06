using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVCViewsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVCViewsDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AuthDb;Integrated Security=True;Pooling=False";
            services.AddDbContext<CarsContext>(o => o.UseSqlServer(connString));
            services.AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connString));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = "/user/login";
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseIdentity()
                .UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    LoginPath = "/user/login"
                });

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
