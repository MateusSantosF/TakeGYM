using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using TakeGYM.Facades.Strategies.ExceptionHandlingStrategies;
using TakeGYM.Models;
using TakeGYM.Models.UI;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestEase;

using Serilog;
using Serilog.Exceptions;

using TakeGYM.Services.Repository;
using TakeGYM.Services.Repository.interfaces;
using TakeGYM.Facades;

namespace TakeGYM.Facades.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string APPLICATION_KEY = "Application";
        private const string SETTINGS_SECTION = "Settings";

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();

            // Dependency injection
            services.AddSingleton(settings)
                    .AddSingleton(settings.BlipBotSettings);

            // MY INTERFACES
            services.AddScoped<ITeacherFacade, TeacherFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IStudentFacade, StudentFacade>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // =========================
            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy(logger) },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy(logger) }
                };
            });

            // SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .ReadFrom.Configuration(configuration)
                     .Enrich.WithMachineName()
                     .Enrich.WithProperty(APPLICATION_KEY, Constants.PROJECT_NAME)
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());
        }
    }
}
