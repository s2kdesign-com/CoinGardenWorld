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
using Microsoft.OpenApi.Models;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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

            var healthTags = new List<string> { "bot", "messages", "api" };
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

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
            });

            #region AddSwagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = $"{Assembly.GetExecutingAssembly().GetName().Version}",
                    Title = "CGW - GardenBOT API",
                    Description = "Backend service API for all external functions of CoinGarden GardenBOT API.",
                    TermsOfService = new Uri("https://coingarden.world/terms-and-conditions"),
                    Contact = new OpenApiContact
                    {
                        Name = "admin@CoinGarden.World",
                        Url = new Uri("http://coingarden.world")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GNU General Public License v3.0",
                        Url = new Uri("https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/LICENSE.txt")
                    }
                });
                // Add Swagger Signalr
                // TODO: Is there a SIGNALR connection here?
                // options.AddSignalRSwaggerGen();


                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


                var microsoftIdentityOptions = new MicrosoftIdentityOptions();
                Configuration.GetSection("AzureAd").Bind(microsoftIdentityOptions);
                // Enabled OAuth security in Swagger
                var scopesConfig = Configuration.GetValue<string>("AzureAd:Scopes").Split(' ');
                var scopes = new Dictionary<string, string>();
                foreach (var scope in scopesConfig)
                {
                    scopes.Add($"https://{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.ClientId}/{scope}", "");

                }
                options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "oauth2",

                In = ParameterLocation.Header
            },
            new List <string> ()
        }
    });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{microsoftIdentityOptions.Instance}/{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.SignUpSignInPolicyId}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"{microsoftIdentityOptions.Instance}/{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.SignUpSignInPolicyId}/oauth2/v2.0/token"),
                            Scopes = scopes,

                        }
                    },
                });

            });
            #endregion

            services.AddBotRuntime(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //Localhost-CoinGarden-Mobile-Web-SwaggerUI
                options.OAuthAppName("Swagger Client");
                options.OAuthClientId(Configuration.GetValue<string>("SwaggerUI:ClientId"));
                options.OAuthClientSecret(Configuration.GetValue<string>("SwaggerUI:ClientSecret"));
                options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                //options.OAuth2RedirectUrl("https://localhost:8002/swagger/oauth2-redirect.html");
                //options.OAuthUsePkce();
                //options.RoutePrefix = string.Empty;

            });
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
