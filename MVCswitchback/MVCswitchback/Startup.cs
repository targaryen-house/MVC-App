using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MVCswitchback.Data;
using Microsoft.Extensions.Configuration;
using MVCswitchback.Models;
using MVCswitchback.Models.Services;
using MVCswitchback.Models.Interfaces;

namespace MVCswitchback
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string connectionString = Environment.IsDevelopment()
                                                 ? Configuration["ConnectionStrings:DefaultConnection"]
                                                 : Configuration["ConnectionStrings:ProductionConnection"];

            services.AddDbContext<SwitchbackDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ITrailManager, TrailService>();
            services.AddScoped<IUserInfoManager, UserInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
