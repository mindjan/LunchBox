using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchBox.BE.Contracts.Deal;
using LunchBox.BE.Contracts.Offer;
using LunchBox.BE.Contracts.Restourant;
using LunchBox.BE.Repositories;
using LunchBox.BE.Repositories.Offer;
using LunchBox.BE.Repositories.Restourant;
using LunchBox.BE.Services;
using LunchBox.BE.Services.Offers;
using LunchBox.BE.Services.Restourants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using DayOfWeek = LunchBox.BE.Contracts.Restourant.DayOfWeek;

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

            services.AddTransient<IRestourantRepository>(provider => new RestourantRepository("mongodb://localhost/LunchBox", "Restourants"));
            services.AddTransient<IOfferRepository>(provider => new OfferRepository("mongodb://localhost/LunchBox", "Offers"));
            services.AddScoped<IRestourantService, RestourantService>();
            services.AddScoped<IOffersService, OffersService>();
            services.AddScoped<IDealsAggregate, DealsAggregate>();

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
                cfg.CreateMap<Deal, Models.Deal.Deal>();
                cfg.CreateMap<Models.Deal.Deal, Deal > ();
                cfg.CreateMap<Offer, Models.Offer.Offer>();
                cfg.CreateMap<Models.Offer.Offer, Offer> ();
                cfg.CreateMap<Restourant, Models.Restourant.Restourant>();
                cfg.CreateMap<Models.Restourant.Restourant, Restourant>();
                cfg.CreateMap<Address, Models.Restourant.Address>();
                cfg.CreateMap<Models.Restourant.Address, Address > ();
                cfg.CreateMap<DayOfWeek, Models.Restourant.DayOfWeek>();
                cfg.CreateMap<Models.Restourant.DayOfWeek, DayOfWeek>();
                cfg.CreateMap<Location, Models.Restourant.Location>();
                cfg.CreateMap<Models.Restourant.Location, Location>();
                cfg.CreateMap<WorkingHours, Models.Restourant.WorkingHours>();
                cfg.CreateMap<Models.Restourant.WorkingHours, WorkingHours> ();
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
