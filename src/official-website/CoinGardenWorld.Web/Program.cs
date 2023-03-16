using CoinGardenWorld.Theme;
using CoinGardenWorld.Theme.Shared;
using CoinGardenWorld.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using CoinGardenWorld.Theme.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped(typeof(ThemeJsInterop));

//builder.RootComponents.Add<TopMenu>(".header-main");

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
