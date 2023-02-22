using CoinGardenWorld.Theme;
using CoinGardenWorld.Theme.Shared;
using CoinGardenWorld.Web;
using CoinGardenWorld.Web.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

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

// TODO: Move to WebAssemblyHostExtension
builder.Services.AddLocalization(options => options.ResourcesPath = "Localization");

var host = builder.Build();
// Extension method
await host.SetDefaultCulture();

await builder.Build().RunAsync();
