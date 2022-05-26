using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;
using MISA.WEBAPI.Core.Services;
using MISA.WEBAPI.Infrastructure.Infrastructure;

namespace MISA.WEBAPI.API
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

            //xu ly DI
            services.AddScoped<IAccountInfrastructure,AccountInfrastructure>();
            services.AddScoped<IBillManage,BillManageInfrastructure>();
            services.AddScoped<IBillInfrastructure, BillInfrastructure>();
            services.AddScoped<IAdminAccountInfrastructure, AccountAdminInfrastructure>();
            services.AddScoped ( typeof(IBaseService<>),typeof(BaseService<>) );
            services.AddScoped(typeof(IBaseInfrastructure<>), typeof(BaseInfrastructure<>));
            //Cors
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.Ò
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
