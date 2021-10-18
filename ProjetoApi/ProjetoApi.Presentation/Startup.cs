using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoApi.Repository.Contexts;
using ProjetoApi.Repository.Contracts;
using ProjetoApi.Repository.Repositories;
using System;


namespace ProjetoApi.Presentation
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

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para gerenciamento de produtos",
                    Version = "v1",
                    Description = "Projeto desenvolvidoem NET CORE API 3.1 com EntityFramework",


                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática - Treinamento C# WebDeveloper",
                        Url = new Uri("http://www.cotiinformatica.com.br"),
                        Email = "contato@cotiinformatica.com.br"
                    }
                });


                
            });

            var connectionString = Configuration.GetConnectionString("ProjetoAPi");

            services.AddDbContext<DataContext>(map => map.UseSqlServer(connectionString));
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            services.AddCors(
                s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithMethods("PUT", "DELETE", "GET");
                })
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("DefaultPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
