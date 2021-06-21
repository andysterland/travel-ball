using FlightApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInfo
{
    public class Startup
    {
        readonly string AllowAllCorsPolicy = "*";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightInfo", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAllCorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });


            services.AddSingleton<IFlightDestinationService, FlightDestinationService>();
            services.AddSingleton<IAirportService, AirportService>();
            services.AddSingleton<IPriceService, PriceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IFlightDestinationService flightService, IAirportService airportService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightInfo v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                     .RequireCors(AllowAllCorsPolicy);
            });

            var user = Configuration["OpenSky:User"];
            var password = Configuration["OpenSky:Password"];
            flightService.Configure(user, password);

            var airportDataPath = Path.Combine(env.ContentRootPath, @"Data\AirportData.csv");
            airportService.Configure(airportDataPath);
        }
    }
}
