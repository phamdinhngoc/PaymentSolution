using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Payment.API.Services;
using Payment.Application.Features.Commands;
using Payment.Application.Interface;
using Payment.Persistence.Persist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Payment.API
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
                c.SwaggerDoc("v1", new OpenApiInfo ()
                { 
                    Title = "Payment service api", 
                    Version = "v1",
                    Description = "Sample .NET payment api",
                    Contact = new OpenApiContact() 
                    {
                        Name= "Test",
                        Url =new Uri("https://yhct.com")
                    }
                });
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var path = Path.Combine(AppContext.BaseDirectory, xmlFileName) ;
                c.IncludeXmlComments(path);
            });
            
            services.AddHttpContextAccessor();
            services.AddScoped<ISqlService, SqlService>();
            services.AddScoped<ICurrentUserService,CurrentUserService>();
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddMediatR(r =>
            {
                r.RegisterServicesFromAssembly(typeof(CreateMerchant).Assembly);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment.API v1"));
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
