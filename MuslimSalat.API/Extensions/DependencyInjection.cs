using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MuslimSalat.BLL.Services;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DAL.Utils;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSwaggerAuthentication(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization: Enter : 'Bearer <token>'"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

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
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new Exception("Configuration is needed for Jwt:Key"))
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

        services.AddScoped<IRepository<Mission>, MissionController>();
        services.AddScoped<IMissionService, MissionService>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<MuslimSalatContext>(options =>
        {
            options.UseSqlServer(EnvironmentFileReader.GetConnectionString());
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
}
