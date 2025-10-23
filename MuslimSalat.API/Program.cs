using MuslimSalat.API.Extensions;
using MuslimSalat.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

EnvironmentFileReader envFile = new();
envFile.Load();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerAuthentication();

builder.Services.AddPersistence();

builder.Services.AddApplicationDependencies();

builder.Services.AddExternalApi(builder.Configuration);

builder.Services.AddJwtAuthentication(builder.Configuration);

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
