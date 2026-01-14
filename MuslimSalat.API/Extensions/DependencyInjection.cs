using System.Text;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MuslimSalat.BLL.Exceptions;
using MuslimSalat.BLL.Services;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new JwtKeyException())
                ),
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = configuration["Jwt:Issuer"],
            };
        });

        return services;
    }

    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IPrayerTimeService, PrayerTimeService>();

        services.AddScoped<IRepository<Prayer>, PrayerRepository>();
        services.AddScoped<IPrayerService, PrayerService>();

        services.AddScoped<IRepository<Mission>, MissionRepository>();
        services.AddScoped<IMissionService, MissionService>();

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEventService, EventService>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MuslimSalatContext>(options =>
        {
            options.UseSqlServer(configuration["CONNECTION_STRING"]);
        });

        return services;
    }

    public static IServiceCollection AddExternalApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(configuration["PrayerTimesApi:Title"]!, client =>
        {
            client.BaseAddress = new Uri(configuration["PrayerTimesApi:BaseUrl"]!);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AngularWebApp", policy =>
            {
                policy.WithOrigins(["http://localhost:4200"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }

    public static IWebHostBuilder AddSentryConfig(this IWebHostBuilder webHostBuilder, IConfiguration configuration)
    {
        return webHostBuilder.UseSentry(o =>
        {
            o.Dsn = configuration["Sentry:Dsn"];
            o.TracesSampleRate = 1.0;
            o.Debug = true;
        });
    }

    public static IServiceCollection AddRateLimiterConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        services.AddInMemoryRateLimiting();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        return services;
    }
}