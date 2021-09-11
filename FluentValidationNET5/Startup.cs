using FluentValidation.AspNetCore;
using FluentValidationNET5.Models.Context;
using FluentValidationNET5.Repositories;
using FluentValidationNET5.Repositories.Interfaces;
using FluentValidationNET5.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FluentValidationNET5
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
            // Configuração FluentValidation: Validação Automática
            services.AddControllers()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

            // Configuração EntityFramework
            var connectionString = Configuration["ConnectionStrings:MySQLConnectionString"];
            services.AddDbContext<ApplicationContext>(options =>  options.UseMySql(connectionString, 
                                                                                    ServerVersion.AutoDetect(connectionString)));

            // Configuração Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FluentValidationNET5", Version = "v1" });
            });

            // Dependency Injection (DI)
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            // Configuração Explícita do FluentValidation com Injeção de Dependência
            //services.AddScoped<IValidator<Student>, StudentValidator>();
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

            app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluentValidationNET5 v1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
