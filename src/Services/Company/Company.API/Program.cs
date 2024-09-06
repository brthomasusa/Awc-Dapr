var appName = "Company API";
var builder = WebApplication.CreateBuilder(args);
builder.AddCustomSerilog();

try
{
    builder.AddCustomConfiguration();
    builder.AddCustomSwagger();
    builder.AddCustomHealthChecks();
    builder.AddCustomApplicationServices();
    builder.Services.AddMappings();
    builder.Services.AddMediatr();
    builder.AddCustomDatabase();
    // builder.Services.AddPersistence();

    builder.Services.AddDaprClient();
    builder.Services.AddControllers();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseCustomSwagger();
    }

    var pathBase = builder.Configuration["PATH_BASE"];
    if (!string.IsNullOrEmpty(pathBase))
    {
        app.UsePathBase(pathBase);
    }

    app.UseCloudEvents();

    app.MapGet("/", () => Results.LocalRedirect("~/swagger"));
    app.MapControllers();
    app.MapSubscribeHandler();
    app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

        app.Logger.LogInformation("Applying database migration ({ApplicationName})...", appName);

        // app.ApplyDatabaseMigration();

        app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
        app.Run();
    }
catch (Exception ex)
{
    Serilog.Log.Fatal(ex, "Company API microservice terminated unexpectedly with message {ex.Message}.", ex.Message);
}
finally
{
    Serilog.Log.CloseAndFlush();
}
