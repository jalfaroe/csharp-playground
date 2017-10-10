using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using reserby.Reservations.API.Application.Services;
using reserby.Reservations.API.Domain.Repositories;
using reserby.Reservations.API.Infrastructure.CrossCutting.Resources;
using reserby.Reservations.API.Infrastructure.Data.Context;
using reserby.Reservations.API.Infrastructure.Data.Repositories;

namespace reserby.Reservations.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(setupAction => { setupAction.ReturnHttpNotAcceptable = true; }
            ).AddJsonFormatters();

            services.AddAutoMapper();

            services.AddDbContext<ReservationsContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ReservationsConnection")));

            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationAppService, ReservationAppService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                UseGlobalExceptionHandler(app);

            app.UseMvc();
        }

        private static void UseGlobalExceptionHandler(IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(CommonResources.ErrorUnexpectedFault);
                });
            });
        }
    }
}