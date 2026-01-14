using DotNetEnv;
using MuslimSalat.API.Extensions;
using MuslimSalat.API.Middlewares;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddSentryConfig(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddExternalApi(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddRateLimiterConfig(builder.Configuration);

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

app.UseSentryTracing();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();