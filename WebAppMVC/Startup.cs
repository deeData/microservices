using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models.Auth;
using WebAppMVC.RestClients;
using WebAppMVC.Services;
using WebAppMVC.Services.Authentication;

namespace WebAppMVC
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
            //add connection for Identity Framework
            services.AddDbContext<AuthDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AuthConnection")));
            //add Idenity Framework to db
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();
            
            //to be available to Controller via dependency injection
            services.AddScoped<IRegisterModel, RegisterModel>();
            services.AddScoped<IEmail, Email>();
            //add http client as dependency injection for API calls using Refit 
            services.AddHttpClient<IBillingTransactionsApi, BillingTransactionsApi>();

            //to refresh view and see changes without restarting
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

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

            //require user logins- Identity Framework
            app.UseAuthentication();

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
