using CoinGardenWorld.Theme;
using CoinGardenWorld.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using CoinGardenWorld.Theme.Extensions;
using CoinGardenWorld.Theme.Configurations;
using CoinGardenWorld.Theme.Models.Shared;
using CoinGardenWorld.Theme.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Singleton with the top menu implementation 
// TODO: Move this to Theme library - you can scan the entry assembly for classes that implement ITopMenu
builder.Services.AddSingleton<ITopMenu, TopMenu>();

// CoinGardenWorld.Theme
await builder.AddCgwHttpClientExtensions();

//builder.Services.AddScoped(typeof(ThemeJsInterop));

//builder.RootComponents.Add<Footer>("footer");

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

// CoinGardenWorld.Theme
builder.Services.AddCgwThemeExtensions();

var host = builder.Build();

// Extension method
await host.SetDefaultCulture();

await builder.Build().RunAsync();
