﻿using LunchBox.BE.Repositories.Deal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace LunchBox.BE
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IDealRepository>(provider => new DealRepository("mongodb://localhost/LunchBox", "LunchDeals"));


            services.AddLogging();

//            // Add our repository type
//            services.AddSingleton<ITodoRepository, TodoRepository>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
//                cfg.CreateMap<Deal, Models.Deal.Deal>();
//                cfg.CreateMap<Models.Deal.Deal, Deal > ();
//                cfg.CreateMap<Offer, Models.Offer.Offer>();
//                cfg.CreateMap<Models.Offer.Offer, Offer> ();
//                cfg.CreateMap<Restaurant, Models.Restaurant.Restaurant>();
//                cfg.CreateMap<Models.Restaurant.Restaurant, Restaurant>();
//                cfg.CreateMap<Address, Models.Restaurant.Address>();
//                cfg.CreateMap<Models.Restaurant.Address, Address > ();
//                cfg.CreateMap<DayOfWeek, Models.Restaurant.DayOfWeek>();
//                cfg.CreateMap<Models.Restaurant.DayOfWeek, DayOfWeek>();
//                cfg.CreateMap<Location, Models.Restaurant.Location>();
//                cfg.CreateMap<Models.Restaurant.Location, Location>();
//                cfg.CreateMap<WorkingHours, Models.Restaurant.WorkingHours>();
//                cfg.CreateMap<Models.Restaurant.WorkingHours, WorkingHours> ();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
