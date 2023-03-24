using CoinGardenWorld.IdentityServer;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try {
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddApplicationInsightsTelemetry();

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    Log.Information("Seeding database...");
    if (args.Contains("/seed"))
        SeedData.MigrateDatabase(app, true);
    else
        SeedData.MigrateDatabase(app);

    Log.Information("Done seeding database. Exiting.");

    app.Run();
}
catch (Exception ex) when (ex.GetType().Name is not "StopTheHostException") // https://github.com/dotnet/runtime/issues/60600
{
    Log.Fatal(ex, "Unhandled exception");
}
finally {
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}