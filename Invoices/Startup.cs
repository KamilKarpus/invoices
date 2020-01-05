using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Application.Configuration;
using Autofac;
using Invoices.Application.Configuration;
using Invoices.Application.Configuration.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Invoices
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AdministrationAutofacModule());
            builder.RegisterModule(new InvoicesAutofacModule());

            AdministrationStartup.Initialize("Server=127.0.0.1;Port=5432;Database=invoices;User Id=invoices_user;Password=invoices;");
            InvoicesStartup.Initialize("Server=127.0.0.1;Port=5432;Database=invoices;User Id=invoices_user;Password=invoices;");
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
