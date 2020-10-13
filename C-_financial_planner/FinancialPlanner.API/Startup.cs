using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.API.Controllers;
using FinancialPlanner.API.Data_Access_Layer;
using FinancialPlanner.API.Service_Layer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Npgsql;

namespace FinancialPlanner.API
{
    public class Startup
    {

        public static IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            //var connectionString = "User ID=user;Password=!3Reshme8;Host=localhost;Port=5432;Database=FinancialPlanner;Pooling=true;";
            var connectionString =
                "Data Source=localhost;Database=FinancialPlanner;Integrated Security=True;Connection Timeout=300;MultipleActiveResultSets=true";

 
            //services.AddDbContext<FinancialPlannerContext>(options => options.UseNpgsql(connectionString));
            services.AddDbContext<FinancialPlannerContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IMainRepository, MainRepository>();
            services.AddScoped<TransactionService, TransactionService>();
            services.AddScoped<BankAccountService, BankAccountService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactor, FinancialPlannerContext financialPlannerContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            financialPlannerContext.EnsureSeedDataForContext();
        }
    }
}
