using System;
using System.Configuration;
using System.Reflection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Runtime.Extensions;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

[assembly: FunctionsStartup(typeof(CoinGardenBotCore.Startup))]

namespace CoinGardenBotCore
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Use Azure Blob storage, instead of in-memory storage.
            
            
            builder.Services.AddSingleton<IStorage>(
                new BlobsStorage(
                    Environment.GetEnvironmentVariable("BlobConnectionString"),
                    Environment.GetEnvironmentVariable("BlobContainerName")
                ));
            builder.Services.AddBotRuntime(builder.GetContext().Configuration);

            builder.Services.AddHealthChecks().AddCheck("self", () =>
                HealthCheckResult.Healthy("Build Version: " + Assembly.GetExecutingAssembly()?.GetName().Version));
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder configurationBuilder)
        {
            FunctionsHostBuilderContext context = configurationBuilder.GetContext();

            string applicationRoot = context.ApplicationRootPath;
            string environmentName = context.EnvironmentName;
            string settingsDirectory = "settings";

            configurationBuilder.ConfigurationBuilder.AddBotRuntimeConfiguration(
                applicationRoot,
                settingsDirectory,
                environmentName);
        }
    }
}