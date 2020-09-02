using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibraryStockChartingApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockChartingApp.StockExchangeMS.Models;
using StockChartingApp.StockExchangeMS.Repositories;
using StockChartingApp.StockExchangeMS.Services;

namespace StockChartingApp.StockExchangeMS
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
            services.AddDbContext<StockExchangeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            //services.AddDbContext<CompanyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddScoped<IRepository<StockExchange>, StockExchangeRepository>();
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IJoinRepository<JoinCompanyStockExchange>, JoinCompanyStockExchangeRepository>();
            services.AddScoped<IRepository<StockPrice>, StockPriceRepository>();

            //Services
            services.AddScoped<StockExchangeService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<GetAllCompanyListService>();
            services.AddScoped<JoinCompanyStockExchangeService>();
            services.AddScoped<StockPriceService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["JwtIssuer"],
                       ValidAudience = Configuration["JwtIssuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]))
                   };
               });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
