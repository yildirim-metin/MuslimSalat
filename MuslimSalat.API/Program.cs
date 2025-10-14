using Microsoft.EntityFrameworkCore;
using MuslimSalat.BLL.Services;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

EnvironmentFileReader envFile = new();
envFile.Load();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MuslimSalatContext>(options =>
{
    options.UseSqlServer(EnvironmentFileReader.GetConnectionString());
});

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
