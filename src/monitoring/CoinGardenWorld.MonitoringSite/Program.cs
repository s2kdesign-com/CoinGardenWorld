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


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
    
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();



var externalApisSettings = new ExternalApisSettings();
builder.Configuration.Bind(externalApisSettings);

builder.Services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.SaveTokens = true;
        foreach (var externalApi in externalApisSettings.ExternalApis)
        {
            foreach (var valueApiScope in externalApi.Value.Api_Scopes)
            {
                options.Scope.Add(valueApiScope);

            }
        }

        options.Scope.Add("offline_access");
    });


#region HttpClients


// Add CoinGardenWorld.HttpClientsExtensions  
var configuredWebsiteUrls = builder.WebHost.GetSetting(WebHostDefaults.ServerUrlsKey)?.Split(";").FirstOrDefault(g => g.StartsWith("https://"));
builder.Services.AddMobileApiHttpClients(externalApisSettings, configuredWebsiteUrls ?? "https://status-coingardenworld.azurewebsites.net/", EnvironmentType.ASPNET);

#endregion

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
