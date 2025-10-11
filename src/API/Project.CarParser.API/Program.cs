Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
                                      .Enrich.FromLogContext()
                                      .WriteTo.Console()
                                      .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Register Services
    builder.AddApplicationServices();
    WebApplication? app;
    try
    {
        app = builder.Build();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Startup error: " + ex.Message);
        throw;
    }

    // Register Middlewares
    app.ConfigurePipeline();

    app.UseHttpsRedirection();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal("An error occurred during application startup: {Message}", ex.Message);
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}