using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using SpeedWalkerWebApi.Models;
using SpeedWalkerWebApi.Repository;

namespace SpeedWalkerWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;

            loggerFactory.AddFile("Logs/SpeedWalkerApi-{Date}.txt");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GCSAppraisalDBContext>(item => item.UseSqlServer
(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGCSAppraisalRepository, GCSAppraisalRepository>();

            services.AddCors();
            services.AddMvc();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
            app.UseMvc();

        }
    }
}
