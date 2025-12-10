using MuslimSalat.API.Extensions;
using MuslimSalat.API.Middlewares;
using MuslimSalat.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);


EnvironmentFileReader envFile = new();
envFile.Load();

builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.AddPersistence();
builder.Services.AddApplicationDependencies();
builder.Services.AddExternalApi(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCors();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenApi v1");
    });

    app.UseCors("AngularWebApp");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();