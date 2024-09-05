using Serilog;

namespace Awc.Dapr.Services.Company.API
{
    public static class ProgramExtensions
    {
        private const string AppName = "Company API";
        private static readonly string[] tags = new [] { "catalogdb" };

        public static void AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddDaprSecretStore(
            "awcdapr-secretstore",
            new DaprClientBuilder().Build());
        }

        public static void AddCustomSerilog(this WebApplicationBuilder builder)
        {
            var seqServerUrl = builder.Configuration["SeqServerUrl"];

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .WriteTo.Seq(seqServerUrl!)
                .Enrich.WithProperty("ApplicationName", AppName)
                .CreateLogger();

            builder.Host.UseSerilog();
        }

        public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = $"AwcDapr - {AppName}", Version = "v1" }));

        public static void UseCustomSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} V1"));
        }

        public static void AddCustomHealthChecks(this WebApplicationBuilder builder) =>
            builder.Services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDapr()
                .AddSqlServer(
                    builder.Configuration["ConnectionStrings:CatalogDB"]!,
                    name: "CompanyAPI-check",
                    tags: tags);

        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEventBus, DaprEventBus>();
        }

        // public static void AddCustomDatabase(this WebApplicationBuilder builder)
        // {
        //     builder.Services.AddDbContext<CatalogDbContext>(
        //         options => options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogDB"]!));
        // }



    }
}