using Application;
using Application.Commands;
using Application.Queries;
using EfDataAccess;
using Implementation.Commands;
using Implementation.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //UseCase
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EFGetCategoryQuery>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();

            services.AddTransient<ICreateNewsCommand, EfCreateNewsCommand>();
            services.AddTransient<IUpdateNewsCommand, EfUpdateNewsCommand>();
            services.AddTransient<IDeleteNewsCommand, EfDeleteNewsCommand>();
            services.AddTransient<IGetNewsQuery, EfGetNewsQuery>();
            services.AddTransient<IGetOneNewsQuery, EfGetOneNewsQuery>();

            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IGetCommentQuery, EfGetCommentQuery>();
            services.AddTransient<IGetOneCommentQuery, EfGetOneCommentQuery>();

            services.AddTransient<ICreateTextCommand, EfCreateTextCommand>();
            services.AddTransient<IUpdateTextCommand, EfUpdateTextCommand>();
            services.AddTransient<IDeleteTextCommand, EfDeleteTextCommand>();
            services.AddTransient<IGetTextQuery, EfGetTextQuery>();
            services.AddTransient<IGetOneTextQuery, EfGetOneTextQuery>();

            services.AddTransient<ICreatePictureCommand, EfCreatePictureCommand>();
            services.AddTransient<IUpdatePictureCommand, EfUpdatePictureCommand>();
            services.AddTransient<IDeletePictureCommand, EfDeletePictureCommand>();
            services.AddTransient<IGetPictureQuery, EfGetPictureQuery>();
            services.AddTransient<IGetOnePictureQuery, EfGetOnePictureQuery>();

            services.AddTransient<ICreateAuditLogCommand, EfCreateAuditLogCommand>();
            services.AddTransient<IUpdateAuditLogCommand, EfUpdateAuditLogCommand>();
            services.AddTransient<IDeleteAuditLogCommand, EfDeleteAuditLogCommand>();
            services.AddTransient<IGetAuditLogQuery, EfGetAuditLogQuery>();
            services.AddTransient<IGetOneAuditLogQuery, EfGetOneAuditLogQuery>();

        }

        public static void AddAplicationActor(this IServiceCollection services)
        {
            //ApplicationActor
            services.AddHttpContextAccessor();

            //services.AddTransient<IApplicationActor, FakeApiUser>();
            services.AddTransient<IApplicationActor>(x => {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    //throw new InvalidOperationException("Actor data doesnt exist in token.");
                   return new AnonymousActor();//kada se odradi registracija ovo ukljucuje a ovo iznad iskljucuje
                }

                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);
                return actor;

            });

        }
        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            //Jwt
            services.AddTransient<JwtManager>();
            services.AddHttpContextAccessor();
           /* services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<afContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });
            */

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            
        }
    }
}
