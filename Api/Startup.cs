using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Api.Core;
using Application;
using Application.Commands;
using Application.Email;
using Application.Queries;
using EfDataAccess;
using Implementation.Commands;
using Implementation.Email;
using Implementation.Logging;
using Implementation.Queries;
using Implementation.Validators;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

namespace Api
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
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddTransient<afContext>();
            services.AddControllers();
            services.AddTransient<UseCaseExecutor>();
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUseCommand>();
            services.AddTransient<NewsValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<TextValidator>();
            services.AddTransient<CommentValidator>();

            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
           // services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddUseCases();

            services.AddAplicationActor();

            services.AddJwt(appSettings);
            services.AddTransient<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(appSettings.EmailFrom, appSettings.EmailPassword));

            //Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "af_311_14", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });
            
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();
            app.UseStaticFiles(); //za prikazivanje slike u browser-u
            app.UseMiddleware<GlobalExceptionHandler>();//regulisanje exeption-a
            app.UseAuthentication();//jwt
            app.UseAuthorization();//jwt

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

    

