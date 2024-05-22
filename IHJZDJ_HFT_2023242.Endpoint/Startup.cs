using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Models;
using IHJZDJ_HFT_2023242.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddControllers();
            services.AddScoped<IDogLogic, DogLogic>();
            services.AddScoped<IBreedLogic, BreedLogic>();
            services.AddScoped<IOwnerLogic, OwnerLogic>();
            services.AddTransient<IRepository<Dog>, DogRepository>();
            services.AddTransient<IRepository<Nation>, NationRepository>();
            services.AddTransient<IRepository<Team>, TeamRepository>();
            services.AddScoped<BasketballDbContext, BasketballDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E4YCWZ_HFT_2022232.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
