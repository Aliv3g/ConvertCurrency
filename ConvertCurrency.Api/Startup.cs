using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ConvertCurrency.Domain.Contracts.Repositories;
using ConvertCurrency.Domain.Contracts.Services;
using ConvertCurrency.Services;
using ConvertCurrency.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ConvertCurrency.Api
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

            // Repository depedency resolve
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            // Service depedency resolve
            services.AddScoped<ICurrencyServices,CurrencyServices>();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ConvertCurrency.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Habilita o middleware para servir o Swagger como um endpoint JSON
            app.UseSwagger();

            //--http://localhost:51646/swagger/index.html
            // Habilita o middler para servir 0 swagger-ui 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConvertCurrency.Api v1");
            });
        }
    }
}
