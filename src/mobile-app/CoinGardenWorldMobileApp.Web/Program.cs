using CoinGardenWorld.Theme.Configurations;
using CoinGardenWorldMobileApp.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add External APIs Http clients 
var externalApisConfig = new ExternalApisSettings();
builder.Configuration.Bind(externalApisConfig);

foreach (var externalApisSetting in externalApisConfig.ExternalApis)
{
    builder.Services.AddHttpClient(externalApisSetting.Key, client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url))
        .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
            .ConfigureHandler(
                authorizedUrls: new[] { externalApisSetting.Value.Api_Url },
                scopes: externalApisSetting.Value.Api_Scopes));

    builder.Services.AddHttpClient($"{externalApisSetting.Key}.NoAuthenticationClient",
        client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url));
}

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CGW.MobileAppApi"));
// END Add API Http clients 

builder.Services.AddMsalAuthentication(options => {
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

await builder.Build().RunAsync();
