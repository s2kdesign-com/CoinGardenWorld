using CoinGardenWorld.Theme.Configurations;
using CoinGardenWorld.Theme.Extensions;
using CoinGardenWorld.Theme.Models.Shared;
using CoinGardenWorldMobileApp.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Singleton with the top menu implementation 
// TODO: Move this to Theme library - you can scan the entry assembly for classes that implement ITopMenu
builder.Services.AddSingleton<ITopMenu, TopMenu>();
// Add External APIs Http clients 
var externalApisConfig = new ExternalApisSettings();
builder.Configuration.Bind(externalApisConfig);

// CoinGardenWorld.Theme
await builder.AddCgwHttpClientExtensions(externalApisConfig);

builder.Services.AddMsalAuthentication(options => {
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

    foreach (var externalApisSetting in externalApisConfig.ExternalApis) {
        foreach (var apiScope in externalApisSetting.Value.Api_Scopes) {
            options.ProviderOptions.DefaultAccessTokenScopes.Add(apiScope);
        }

    }

});


// CoinGardenWorld.Theme
builder.Services.AddCgwThemeExtensions();

var host = builder.Build();

// Extension method
await host.SetDefaultCulture();

await builder.Build().RunAsync();
