using AutoMapper;
using BillingApi;
using BillingApi.DbContexts;
using BillingApi.Hubs;
using BillingApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //connection to and service in Db
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //SignalR - communicate to client after event from backend (backend to client notification)
            services.AddSignalR()
                //payload json serialization option to null (means do not change the default camel casing)
                .AddJsonProtocol(options =>
                {
                    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                });

            //create mapper and add as singleton, configure to .netcoreAPI, set mapping rules in MappingConfig file
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            //add AutoMapper for DTO conversion
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //IRepository pattern accessible to Controller
            services.AddScoped<IBillingTransactionsRepository, BillingTransactionsRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      //need to specify origin for SignalR CORS
                                      builder.WithOrigins("https://localhost:44315")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod()
                                             .AllowCredentials();
                                  });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = Configuration.GetValue<string>("StripeApiKey");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentApi v1"));
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //add SignalR endpoint for its newly created hub class to trigger client methods
                endpoints.MapHub<PaidHub>("/paidhub");
            });
        }
    }
}
