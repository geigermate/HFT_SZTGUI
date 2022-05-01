using F27T0P_HFT_2021222.Logic;
using F27T0P_HFT_2021222.Logic.Interfaces;
using F27T0P_HFT_2021222.Models;
using F27T0P_HFT_2021222.Repository;
using F27T0P_HFT_2021222.Repository.ModelRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GpuCustomerDbContext>();

            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<GpuType>, GpuTypeRepository>();
            services.AddTransient<IRepository<Customer>, CustomerRepository>();

            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IGpuTypeLogic, GpuTypeLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "F27T0P_HFT_2021222.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "F27T0P_HFT_2021222.Endpoint v1"); c.RoutePrefix = String.Empty; });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", @"F27T0P_HFT_2021222.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
