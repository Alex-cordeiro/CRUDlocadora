using CRMLocadora.Context;
using CRMLocadora.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRMLocadora
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;


        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //configuring services
            services.AddTransient<ClienteService, ClienteService>();
            services.AddTransient<FilmeService, FilmeService>();




            var connectionString = Configuration["ConnectionStrings:Mysql"];

            services.AddDbContext<LocadoraContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMBiblioteca", Version = "v1" });
            });

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connectionString);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRMBiblioteca v1"));


            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                //var conn = new MySqlConnector(Configuration.GetConnectionString(connection));
            }
            catch (Exception ex)
            {
                Log.Error("Database migration Failed", ex);

                throw;
            }
        }
    }
}
