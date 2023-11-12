using CoinGardenWorldMobileApp.DotNetApi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using CoinGardenWorld.AzureAI.Extensions;
using CoinGardenWorldMobileApp.DotNetApi.Controllers;
using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using CoinGardenWorldMobileApp.DotNetApi.Hubs;
//using Hangfire;
using Microsoft.Extensions.Azure;
using CoinGardenWorld.AzureStorageExtensions.Extensions;
using CoinGardenWorld.AzureStorageExtensions.Configuration;
using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using Microsoft.AspNetCore.OData;
using CoinGardenWorldMobileApp.DotNetApi.OperationFilter;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

#region Add ApplicationInsights 

var appInsightsConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];

builder.Services.AddApplicationInsightsTelemetry(appInsightsConnectionString);

builder.Logging.AddApplicationInsights(configuration =>
{
    configuration.ConnectionString = appInsightsConnectionString;
}, options =>
{
    options.IncludeScopes = true;
});

#endregion

#region Add Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", config =>
    {
        config.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

#endregion

#region Add Authentication

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

#endregion

#region Add OData

var modelBuilder = new ODataConventionModelBuilder();

//modelBuilder.EntityType<Account>();
//modelBuilder.EntityType<Post>();
//modelBuilder.EntityType<Flower>();

// this will register new actions GET and POST and will conflict with the base OData controller so we add OData to the end of the action
modelBuilder.EntitySet<Account>("AccountsOData");
modelBuilder.EntitySet<Post>("PostsOData");
modelBuilder.EntitySet<Flower>("FlowersOData");

builder.Services.AddControllers(cOptions =>
{

    cOptions.RespectBrowserAcceptHeader = true;
})
    .AddOData(options => {
        options.EnableQueryFeatures(50).AddRouteComponents("odata",modelBuilder.GetEdmModel());
        options.EnableNoDollarQueryOptions = true;
        }
    
    );

#endregion

#region Add SignalR

// Add signalr

// TODO: This is not needed because we dont use serverless signalr, current hubs are directly resolved with the help of azure signalr and rooted 
//builder.Services
//    .AddSingleton<SignalRService>()
//    .AddHostedService(sp => sp.GetService<SignalRService>())
//    .AddSingleton<IHubContextStore>(sp => sp.GetService<SignalRService>());

builder.Services.AddSignalR().AddAzureSignalR(configure =>
{
    // TODO: indicate success: 429 (Too Many Requests) signalr
    // the initial value was 5 but we got exception
    // https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-concept-internals#application-server-connections
    configure.InitialHubServerConnectionCount = 1;
});

#endregion

#region Add Swagger

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    // OData $metadata url is braking the generated HTTP clients so its better to ignore it in the docs
    options.DocumentFilter<HideInDocsFilter>();

    options.OperationFilter<ODataParametersSwaggerDefinition>();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = $"{Assembly.GetExecutingAssembly().GetName().Version}",
        Title = "CGW - Mobile APP API",
        Description = "Backend service API for all external functions of CoinGarden Mobile API.",
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
   // options.AddSignalRSwaggerGen();


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    var microsoftIdentityOptions = new MicrosoftIdentityOptions();
    builder.Configuration.GetSection("AzureAd").Bind(microsoftIdentityOptions);
    // Enabled OAuth security in Swagger
    var scopesConfig = builder.Configuration.GetValue<string>("AzureAd:Scopes").Split(' ');
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
                Scopes = scopes
            }
        }
    });

});

#endregion

#region Add Sql Server

// Add SQL Server Database
builder.Services.AddDbContext<MobileAppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB")));

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(UnitOfWork<>));

#endregion

#region Add Azure Blob Storage
// Add Azure Storage
var azureStorageConfiguration = new AzureStorageConfiguration();
builder.Configuration.Bind("AzureStorage", azureStorageConfiguration);

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddCgwFileServiceClient(azureStorageConfiguration.Blob, preferMsi: true);
    clientBuilder.AddCgwQueueServiceClient(azureStorageConfiguration.Queue, preferMsi: true);
    clientBuilder.AddCgwBlobServiceClient(azureStorageConfiguration.Files, preferMsi: true);
});

#endregion

#region Add HealhChecks

// Add Health Checks
var notificationHubUrl = "https://plant-api.azurewebsites.net/NotificationsHub";
var chatHubUrl = "https://plant-api.azurewebsites.net/ChatHub";

var hangfireUrl = "https://plant-api.azurewebsites.net/hangfire";

#if DEBUG
notificationHubUrl = "https://localhost:7249/NotificationsHub";
chatHubUrl = "https://localhost:7249/ChatHub";

hangfireUrl = "https://localhost:7249/hangfire";
#endif

var healthTags = new List<string> { "mobileapp", "api" };
var healthTagsDatabase = new List<string> { "mobileapp", "database"  };
var healthTagsSignalR = new List<string> { "mobileapp", "signalr"  };
var healthTagsHangFire = new List<string> { "mobileapp", "hangfire" };
var healthTagsAzureStorage = new List<string> { "mobileapp", "azurestorage" };

builder.Services.AddHealthChecks()
    // Self
    .AddCheck("https://plant-api.azurewebsites.net/swagger/index", () => HealthCheckResult.Healthy("Build Version: " + Assembly.GetExecutingAssembly().GetName().Version), healthTags)
    // SQL Database
    .AddSqlServer(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB"), "SELECT TOP (1) * FROM [dbo].[Flowers]", name: "Mobile APP - Database", tags: healthTagsDatabase)
    // Azure Storage
    .AddAzureBlobStorage(azureStorageConfiguration.Blob, tags: healthTagsAzureStorage, name: "Azure Blob Storage")
    .AddAzureQueueStorage(azureStorageConfiguration.Queue, tags: healthTagsAzureStorage, name: "Azure Queue Storage")
    .AddAzureFileShare(azureStorageConfiguration.Files, tags: healthTagsAzureStorage, name: "Azure File Storage")

    // Hangfire
    .AddHangfire(opt => { opt.MinimumAvailableServers = 1; opt.MaximumJobsFailed = 1; }, name: hangfireUrl, tags: healthTagsHangFire)
    // SignalR Hubs
    .AddSignalRHub(notificationHubUrl, name: notificationHubUrl, tags: healthTagsSignalR)
#if DEBUG
    // TODO: Signalr hub is authenticated so the check is failing 
  //  .AddSignalRHub(chatHubUrl, name: chatHubUrl, tags: healthTagsSignalR)
#endif
    ;

#endregion

#region Add Rate Limiter

builder.Services.AddRateLimiter(options => {
    options.AddFixedWindowLimiter("Fixed", opt => {
        opt.Window = TimeSpan.FromSeconds(60);
        opt.PermitLimit = 20;
    });
});

#endregion

// TODO: Move to CoinGardenWorld.AzureAI
builder.Services.AddAzureComputerVision();
builder.Services.AddAzureWebSearch();

// TODO: Add Hangfire to another API , this will have a lot of traffic 
//builder.Services.AddHangfire(c => c.UseSqlServerStorage(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB")));
//builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseCors("AllowAllCors");

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MobileAppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseODataRouteDebug();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();


#region use Swagger

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    //Localhost-CoinGarden-Mobile-Web-SwaggerUI
    options.OAuthAppName("Swagger Client");
    options.OAuthClientId(builder.Configuration.GetValue<string>("SwaggerUI:ClientId"));
    options.OAuthClientSecret(builder.Configuration.GetValue<string>("SwaggerUI:ClientSecret"));
    options.OAuthUseBasicAuthenticationWithAccessCodeGrant();

});

#endregion

app.MapHub<NotificationsHub>("NotificationsHub");
app.MapHub<ChatHub>("ChatHub");

#region Use HealthChecks

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

#endregion

// TODO: Add Hangfire to another API , this will have a lot of traffic 
//var options = new DashboardOptions { AppPath = "https://plant-api.azurewebsites.net/swagger/index.html" };
//app.UseHangfireDashboard(options: options);

app.Run();
