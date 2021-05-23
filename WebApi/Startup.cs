using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sf.Budgeteer.ApplicationCore.Configuration;
using Sf.Budgeteer.Infrastructure;

namespace Sf.Budgeteer.WebApi
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
            services.AddControllers();

            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));

            services.AddDbContext<BudgeteerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BudgeteerConnection"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo());
                c.EnableAnnotations();
            });

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "DEVELOPMENT")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.RoutePrefix = "/help";
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            //});

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );

            

     

           
        }
    }
}
