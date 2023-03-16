using CoinGardenBotCore.Web;
using CoinGardenWorld.Theme.Extensions;
using CoinGardenWorld.Theme.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("GardenBOT_API_Url")) });

builder.Services.AddMsalAuthentication(options => {
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

// CoinGardenWorld.Theme
builder.Services.AddCgwThemeExtensions();

var host = builder.Build();

// Extension method
await host.SetDefaultCulture();

await builder.Build().RunAsync();
