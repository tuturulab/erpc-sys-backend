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
using System.IO;
using RazorLight;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Http;

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


            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            
            //Database config
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ErpcDbContext>()
                .BuildServiceProvider();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials() );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Upload Images

            services.AddTransient<Handler.IImageHandler, Handler.ImageHandler>();

            services.AddTransient<IImageWriter,ImageWriter>(); //Development

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
            app.UseCors("CorsPolicy");
            app.UseExceptionHandler(appBuilder =>
           {
               appBuilder.Run(async context =>
               {
                   context.Response.Headers.Add("Access-Control-Allow-Origin", "*");   // I needed to add this otherwise in Angular I Would get "Response with status: 0 for URL"
                   context.Response.StatusCode = 500;
                   await context.Response.WriteAsync("Internal Server Error");
               });
           });

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