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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using erpc_system_backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using erpc_system_backend.Models;
using erpc_system_backend.Classes;
using erpc_system_backend.Interface;
using erpc_system_backend.Services;

namespace erpc_system_backend 
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
            services.AddOptions();
            services.Configure<AppKeys>(Configuration.GetSection("AppKeys"));

           
            //Secret key
            string jwtKey = Configuration["AppKeys:JwtSecret"];

            //symmetric security key
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters 
                    {
                        //What to validate
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        //Setup validate data
                        ValidIssuer = "tuturulabs.in",
                        ValidAudience = "admins",
                        IssuerSigningKey = symmetricKey

                    };
                });

            //Database config
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ErpcDbContext>()
                .BuildServiceProvider();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Upload Images

            services.AddTransient<Handler.IImageHandler, Handler.ImageHandler>();

            services.AddTransient<IImageWriter,ImageWriter>();

            services.AddCors(); //Development

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseAuthentication();

            //File Upload
            app.UseStaticFiles();

            //Development
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .WithExposedHeaders("PagingHeader")
            );

            app.UseHttpsRedirection();

            app.UseMvc();

        }


        /* removed form launch.json in vscode
         "serverReadyAction": {
                "action": "openExternally",
                "pattern": "^\\s*Now listening on:\\s+(https?://\\S+)"
            },
         */
    }
}