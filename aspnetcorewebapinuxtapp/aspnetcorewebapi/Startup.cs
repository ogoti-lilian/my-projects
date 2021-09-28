using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection config_serv)
        {
            config_serv.AddAuthentication(auth_opt =>
            {
                auth_opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth_opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt_opt =>
            {
                var config_auth0 = Configuration.GetSection("Config:Auth");

                jwt_opt.Audience = config_auth0["Audience"];
                jwt_opt.Authority = config_auth0["Authority"];
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder config_app, IWebHostEnvironment env)
        {
            config_app.UseHttpsRedirection();

            config_app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            config_app.UseRouting();

            config_app.UseAuthentication();
            config_app.UseAuthorization();

            config_app.UseEndpoints(my_end_point =>
            {
                my_end_point.MapControllers();
            });
        }
    }
}
