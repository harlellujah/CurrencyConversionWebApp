using CurrencyConverter.Business.ApiManagement;
using CurrencyConverter.Business.Entities.Conversion;
using CurrencyConverter.Common.AppSettings;
using CurrencyConverter.DataAccess.Context;
using CurrencyConverter.DataAccess.Repository;
using CurrencyConverter.Mapping.Base;
using CurrencyConverter.Models.Conversion;
using CurrencyConverter.ServiceLayer.CurrencyManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web
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
            services.AddControllersWithViews();

            services.AddDbContextFactory<CurrencyConversionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddOptions();
            services.Configure<AppSettings>(Configuration);

            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IRepository, SQLRepository>();

            services.AddSingleton<IMapper<ConversionEntity, ConversionModel>, Mapper<ConversionEntity, ConversionModel>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
