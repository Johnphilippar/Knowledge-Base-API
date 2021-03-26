using CLEAN_Domain.AppSettings;
using CLEAN_Domain.Interface;
using CLEAN_Domain.Commands;
using CLEAN_Domain.CommandHandlers;
using CLEAN_Application.Interface;
using CLEAN_Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using CLEAN_Infrastructure_DATA.Context;
using Microsoft.EntityFrameworkCore;
using CLEAN_Infrastructure_DATA.Repository;
using CLEAN_Infrastructure_IOC.Persistence;
using Microsoft.OpenApi.Models;
using CLEAN_Domain.Models;

namespace CLEAN_Infrastructure_IOC
{
    public static class DependencyContainer
    {
        public static ApplicationSettings appSettings = new ApplicationSettings();

        public static void RegisterService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AppSettingsConfiguration(configuration);

            services.AddDbContext<KnowledgeBaseContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(DependencyContainer.appSettings.Databases.TestDB);
            });

            //commands
            services.AddScoped<IRequestHandler<CommentsCommand, CommentsModel>, CommentsHandlers>();
            services.AddScoped<IRequestHandler<CreateCommand, ArticleModel>, CreateHandlers>();
            services.AddScoped<IRequestHandler<UpdateCommand, bool>, UpdateHandlers>();
            services.AddScoped<IRequestHandler<DeleteCommand, bool>, DeleteHandlers>();

            //for Database Context
            services.AddScoped<KnowledgeBaseContext>();

            //Repository infrastructure data
            services.AddScoped<IKnowledgeBaseRepository, KnowledgeBaseRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();

            //Services - Application Layer
            services.AddScoped<IKnowledgeBaseService, KnowledgeBaseService>();
            services.AddScoped<ICommentService, CommentService>();
            services.SwaggerConfiguration();

        }
        public static void AppBuilderConfiguration(this IApplicationBuilder app)
        {
            string version = "1.0.0";
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/" + version + "/swagger.json", "Sample API");
            });

            app.UseFluentValidationExceptionHandler();
            app.UseSwagger();
        }

        public static void AppSettingsConfiguration(this IServiceCollection services , IConfiguration configuration)
        {
            IServiceCollection serviceCollection = services.Configure<DatabasesSettings>(configuration.GetSection("Databases"));
            services.Configure<DatabasesSettings>(configuration.GetSection("Databases"));
            configuration.GetSection("Databases").Bind(appSettings.Databases);
        }
        #region SwaggerConfiguration
        public static void SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("1.0.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Sample Swagger",
                    Version = "1.0.0"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {{
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }});
            });
        }
        #endregion
    }
}
