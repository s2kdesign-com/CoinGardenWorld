using CoinGardenWorld.HttpClientsExtensions.Configurations;
using CoinGardenWorld.HttpClientsExtensions.Extensions;
using CoinGardenWorld.HttpClientsExtensions.Infrastructure;
using CoinGardenWorldMobileApp.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());
builder.Services.AddHealthChecksUI().AddInMemoryStorage();


#if DEBUG
builder.Services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Period = TimeSpan.FromSeconds(10);
});
#endif


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))


    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes: new List<string> {
     //   $"https://{builder.Configuration.GetSection("AzureAd:Domain").Value}/{builder.Configuration.GetSection("AzureAd:ClientId").Value}/access_as_user",
     //   $"https://{builder.Configuration.GetSection("AzureAd:Domain").Value}/{builder.Configuration.GetSection("AzureAd:ClientId").Value}/ReadMonitoringSite",
     //  "offline_access"
    })
    // TODO: Do not use this in production, connect azure cosmos db
    .AddInMemoryTokenCaches();



#region HttpClients


var externalApisSettings = new ExternalApisSettings();
builder.Configuration.Bind(externalApisSettings);
// Add CoinGardenWorld.DownstreamApiExtensions  
var configuredWebsiteUrls = builder.WebHost.GetSetting(WebHostDefaults.ServerUrlsKey)?.Split(";").FirstOrDefault(g => g.StartsWith("https://"));
builder.Services.AddDownStreamApiExtensions(externalApisSettings, configuredWebsiteUrls ?? "https://status-coingardenworld.azurewebsites.net/", EnvironmentType.ASPNET);

#endregion


builder.Services.AddControllersWithViews()
.AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;

});

builder.Services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.SaveTokens = true;
        options.UseTokenLifetime = true;
        options.RefreshInterval = TimeSpan.FromMinutes(50);
        // TODO: Azure AD V2 endpoint allow you to get a token for only one resource at once, however, you can let the user pre-consent for several resources.
        // https://learn.microsoft.com/en-us/entra/msal/dotnet/acquiring-tokens/user-gets-consent-for-multiple-resources

        // TODO: DONT add the scopes to the user , use EnableTokenAcquisitionToCallDownstreamApi from msal
        // read more here https://learn.microsoft.com/en-us/entra/identity-platform/scenario-web-app-call-api-app-configuration?tabs=aspnetcore#option-2-call-adownstream-web-api-other-than-microsoft-graph

        //foreach (var externalApiScope in externalApisSettings.ExternalApis.FirstOrDefault(c => c.Key == "CGW.Mobile.Api").Value.Api_Scopes)
        //{
        //    options.Scope.Add(externalApiScope);
        //}
        options.Scope.Add($"https://{builder.Configuration.GetSection("AzureAd:Domain").Value}/{builder.Configuration.GetSection("AzureAd:ClientId").Value}/access_as_user");
        options.Scope.Add($"https://{builder.Configuration.GetSection("AzureAd:Domain").Value}/{builder.Configuration.GetSection("AzureAd:ClientId").Value}/ReadMonitoringSite");
        options.Scope.Add("offline_access");
        //options.Events.OnTokenValidated = async context =>
        //{
        //    await context.HttpContext.RequestServices
        //        .GetRequiredService<MyClaimsTransformation>()
        //        .TransformAsync(context.Principal!);
        //};
    });


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAllCors");


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");

    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.
            WriteHealthCheckUIResponse
    });
    endpoints.MapHealthChecksUI(config =>
    {
        config.UIPath = "/status";
        config.AddCustomStylesheet(Path.Join("wwwroot", "css", "health-check.css"));


    });
});

app.Run();
