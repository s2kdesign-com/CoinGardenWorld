using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Runtime.Extensions;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Web;

namespace CoinGardenWorldBot_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var healthTags = new List<string> { "bot","messages", "api" };
            services.AddHealthChecks()
                // Self
                .AddCheck("https://coingardenbotcore.azurewebsites.net/", () => HealthCheckResult.Healthy("Build Version: " + Assembly.GetExecutingAssembly().GetName().Version), healthTags)
                // Azure Storage
                //.AddAzureBlobStorage(azureStorageConfiguration.Blob, tags: healthTagsAzureStorage, name: "Azure Blob Storage")
                //.AddAzureQueueStorage(azureStorageConfiguration.Queue, tags: healthTagsAzureStorage, name: "Azure Queue Storage")
                //.AddAzureFileShare(azureStorageConfiguration.Files, tags: healthTagsAzureStorage, name: "Azure File Storage")
                ;
            var azureAdConfig = Configuration.GetSection("AzureAd");
            // Add services to the container.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(azureAdConfig);

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
            });
            services.AddBotRuntime(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            // Set up custom content types - associating file extension to MIME type.
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".lu"] = "application/vnd.microsoft.lu";
            provider.Mappings[".qna"] = "application/vnd.microsoft.qna";

            // Expose static files in manifests folder for skill scenarios.
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });
            app.UseWebSockets();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app
                .UseHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                })
                .UseHealthChecks("/healthz", new HealthCheckOptions
                {
                    Predicate = _ => true
                });
        }
    }
}
