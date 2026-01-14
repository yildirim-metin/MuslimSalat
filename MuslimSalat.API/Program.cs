using DotNetEnv;
using MuslimSalat.API.Extensions;
using MuslimSalat.API.Middlewares;
using MuslimSalat.DAL.Utils;
Env.Load();
var builder = WebApplication.CreateBuilder(args);




// EnvironmentFileReader envFile = new();
// envFile.Load();

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
builder.WebHost.UseSentry(O =>
{
    O.Dsn = builder.Configuration["Sentry:Dsn"];
    // When configuring for a non-HTTP scenario, set tracesSampleRate to 0.0
    O.TracesSampleRate = 1.0;
    O.Debug = true;
});


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