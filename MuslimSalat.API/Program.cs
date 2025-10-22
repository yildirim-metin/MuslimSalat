using Microsoft.EntityFrameworkCore;
using MuslimSalat.API.Extensions;
using MuslimSalat.BLL.Services;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

EnvironmentFileReader envFile = new();
envFile.Load();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.AddSwaggerAuthentication();

builder.Services.AddDbContext<MuslimSalatContext>(options =>
{
    options.UseSqlServer(EnvironmentFileReader.GetConnectionString());
});

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IPrayerTimeService, PrayerTimeService>();

builder.Services.AddHttpClient(builder.Configuration["PrayerTimesApi:Title"]!, client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PrayerTimesApi:BaseUrl"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.AddJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenApi v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
