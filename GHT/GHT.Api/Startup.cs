using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHT.Domine.Data;
using Microsoft.EntityFrameworkCore;
using GHT.Domine.Filters;
using System.Reflection;
using System.IO;
using FluentValidation.AspNetCore;
using GHT.Service.Interfaces;
using GHT.Service.Services;
using GHT.Domine.Seed;
using GHT.Domine.Interface;
using GHT.Domine.Repositories;

namespace GHT.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddSession();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //boot
            services.AddControllers(op => op.Filters.Add<GlobalExceptionFilter>()).AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            //ConnectionString
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //Migrations
            var migrationsAssembly = "GHT.Domine";
            services.AddDbContext<GHTContext>(p => p.UseSqlServer(connectionString, s => s.MigrationsAssembly(migrationsAssembly)));

            ////Inject Dependence
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<IItemsRepository, ItemsRepository>();
            services.AddTransient<IBuysService, BuysService>();
            services.AddTransient<IBuysRepository, BuysRepository>();


            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v01", new OpenApiInfo { Title = "Project GHT API Items", Version = "v01" });
                var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var fileP = Path.Combine(AppContext.BaseDirectory, file);
                swg.IncludeXmlComments(fileP);
            });


            ////filters -Validador
            services.AddMvc(op =>
            {
                //op.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(op =>
            {
                op.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            SeedGHT.SeedGHTServerData(app);

            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v01/swagger.json", "Project GHT API Items");
                sw.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin());

            app.UseCors(options => options.WithOrigins("http://127.0.0.1:5500"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
