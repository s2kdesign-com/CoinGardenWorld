using System.Reflection;
using CoinGardenWorldMobileApp.Maui.Authorization;
using CoinGardenWorldMobileApp.Maui.Data;
using CoinGardenWorldMobileApp.MobileAppTheme;
using CoinGardenWorldMobileApp.MobileAppTheme.Authorization;
using CoinGardenWorldMobileApp.MobileAppTheme.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorldMobileApp.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var assembly = typeof(App).GetTypeInfo().Assembly;

            var config = new ConfigurationBuilder()
                .AddJsonFile( "appsettings.json", true, true)
                .AddJsonFile( "appsettings.Development.json", true, true)
                .Build();

            builder.Configuration.AddConfiguration(config);

            var appInsightsConnectionString = config["ApplicationInsights:ConnectionString"];

            builder.Logging.AddApplicationInsights(configuration =>
            {
                configuration.TelemetryInitializers.Add(new ApplicationInitializer());
                configuration.ConnectionString = appInsightsConnectionString;
            }, options =>
            {
                options.IncludeScopes = true;
            });

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            // CoinGardenWorldMobileApp.MobileAppTheme
            builder.Services.AddMobileAppTheme(EnvironmentType.Mobile, builder.Configuration);

            return builder.Build();
        }
    }
}
