using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockChartingApp.CompanyMS.Models;
using StockChartingApp.CompanyMS.Repositories;
using StockChartingApp.CompanyMS.Services;

namespace StockChartingApp.CompanyMS
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
            services.AddDbContext<CompanyMSContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddScoped<CompanyRepository>();
            services.AddScoped<IPODetailsRepository>();
            services.AddScoped<StockExchangeRepository>();
            services.AddScoped<BoardMemberRepository>();

            services.AddScoped<CompanyService>();
            services.AddScoped<StockExchangeService>();
            services.AddScoped<IPODetailsService>();
            services.AddScoped<BoardMemberService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
