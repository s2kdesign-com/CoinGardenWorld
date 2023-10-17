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
using CoinGardenWorldMobileApp.DotNetApi.Controllers;
using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using CoinGardenWorldMobileApp.DotNetApi.Hubs;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

var appInsightsConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];

builder.Logging.AddApplicationInsights(configuration =>
{
    configuration.ConnectionString = appInsightsConnectionString;
}, options =>
{
    options.IncludeScopes = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", config =>
    {
        config.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var microsoftIdentityOptions = new MicrosoftIdentityOptions();
builder.Configuration.GetSection("AzureAd").Bind(microsoftIdentityOptions);

builder.Services.AddControllers();


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


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
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
    options.AddSignalRSwaggerGen();


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

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

builder.Services.AddDbContext<MobileAppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB")));

// Add Hangfire
builder.Services.AddHangfire(c => c.UseSqlServerStorage(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB")));
builder.Services.AddHangfireServer();



// Add Health Checks
var notificationHubUrl = "https://plant-api.azurewebsites.net/NotificationsHub";
var chatHubUrl = "https://plant-api.azurewebsites.net/ChatHub";

var hangfireUrl = "https://plant-api.azurewebsites.net/hangfire";

#if DEBUG
notificationHubUrl = "https://localhost:7249/NotificationsHub";
chatHubUrl = "https://localhost:7249/ChatHub";

hangfireUrl = "https://localhost:7249/hangfire";
#endif

var healthTags = new List<string> { "mobileapp" };
var healthTagsDatabase = new List<string> { "mobileapp", "database"  };
var healthTagsSignalR = new List<string> { "mobileapp", "signalr"  };
var healthTagsHangFire = new List<string> { "mobileapp", "hangfire" };

builder.Services.AddHealthChecks()
    .AddCheck("https://plant-api.azurewebsites.net/swagger/index", () => HealthCheckResult.Healthy("Build Version: " + Assembly.GetExecutingAssembly().GetName().Version), healthTags)
    .AddSqlServer(builder.Configuration.GetConnectionString("CGW-Mobile-App-DB"), "SELECT TOP (1) * FROM [dbo].[Flowers]", name: "Mobile APP - Database", tags: healthTagsDatabase)
    .AddHangfire(opt => { opt.MinimumAvailableServers = 1; opt.MaximumJobsFailed = 1; }, name: hangfireUrl, tags: healthTagsHangFire)
    .AddSignalRHub(notificationHubUrl, name: notificationHubUrl, tags: healthTagsSignalR)
    .AddSignalRHub(chatHubUrl, name: chatHubUrl, tags: healthTagsSignalR)

    ;

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MobileAppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    //Localhost-CoinGarden-Mobile-Web-SwaggerUI
    options.OAuthAppName("Swagger Client");
    options.OAuthClientId(builder.Configuration.GetValue<string>("SwaggerUI:ClientId"));
    options.OAuthClientSecret(builder.Configuration.GetValue<string>("SwaggerUI:ClientSecret"));
    options.OAuthUseBasicAuthenticationWithAccessCodeGrant();

});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationsHub>("NotificationsHub");
app.MapHub<ChatHub>("ChatHub");

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

app.UseCors("AllowAllCors");


var options = new DashboardOptions { AppPath = "https://plant-api.azurewebsites.net/swagger/index.html" };
app.UseHangfireDashboard(options: options);

app.Run();
