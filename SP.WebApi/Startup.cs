using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository;
using SP.Data.Repository.Interface;
using SP.Services.PersonServices;

namespace SP.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("SpConnectionString");
            services.AddDbContext<SpDataContext>(options => options.UseNpgsql(connectionString));

            #region generic repo and uniofwork
            // register with generic repo
            services.AddScoped<IUnitOfWork<SpDataContext>, EFUnitOfWork<SpDataContext>>();

         
            //optional- register with explicit repo
            services.AddScoped<ISpUnitOfWork, SpEFUnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();//optional
            
            #endregion

            #region services
            services.AddScoped<IPersonService, PersonService>();

            #endregion


            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
