using SparkPoc.Application.Database;
using SparkPoc.Application.Events.Listeners;
using SparkPoc.Application.Models;
using SparkPoc.Application.Services.Auth;
using SparkPoc.Application.Jobs;
using Spark.Library.Database;
using Coravel;
using FluentValidation;
using Spark.Library.Auth;
using Spark.Library.Mail;
using SparkPoc.Pages.Auth;
using Vite.AspNetCore.Extensions;

namespace SparkPoc.Application.Startup;

public static class AppServicesRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
	{
		services.AddViteServices();
		services.AddCustomServices();
        services.AddDatabase<DatabaseContext>(config);
        // services.AddLogger(config);
        services.AddAuthorization(config, new string[] { ApplicationRoles.Admin, ApplicationRoles.User });
        services.AddAuthentication<IAuthValidator>(config);
        services.AddJobServices();
        services.AddScheduler();
        services.AddQueue();
        services.AddEventServices();
        services.AddEvents();
        services.AddMailer(config);
        services.AddRazorComponents();
        services.AddDistributedMemoryCache();
        services.AddSession(options => {
            options.Cookie.Name = ".sparkpoc";
            options.IdleTimeout = TimeSpan.FromMinutes(1);
        });
        return services;
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        // add custom services
        services.AddScoped<UsersService>();
        services.AddScoped<RolesService>();
		services.AddScoped<IAuthValidator, SparkAuthValidator>();
		services.AddScoped<AuthService>();
        services.AddScoped<IValidator<Register.RegisterForm>, Register.RegisterFormValidator>();
		return services;
    }

    private static IServiceCollection AddEventServices(this IServiceCollection services)
    {
        // add custom events here
        services.AddTransient<EmailNewUser>();
        return services;
    }

    private static IServiceCollection AddJobServices(this IServiceCollection services)
    {
        // add custom background tasks here
        services.AddTransient<ExampleJob>();
        return services;
    }
}
