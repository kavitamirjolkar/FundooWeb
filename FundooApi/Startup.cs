using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using FundooBusiness.Interfaces;
using FundooBusiness.Services;
using FundooRepository;
using FundooRepository.DBContext;
using FundooRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FundooApi
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AuthenticationContext>(options =>
              options.UseSqlServer(this.Configuration.GetConnectionString("IdentityConnection")));
            
            services.AddTransient<IApplicationUserBusiness, ApplicationUserBusiness>();
            services.AddTransient<IApplicationUserContextRepository, ApplicationUserContextRepository>();

            services.AddDefaultIdentity<ApplicationUserDBModel>()
                .AddEntityFrameworkStores<AuthenticationContext>();
           
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "localhost";
                option.InstanceName = "master";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
