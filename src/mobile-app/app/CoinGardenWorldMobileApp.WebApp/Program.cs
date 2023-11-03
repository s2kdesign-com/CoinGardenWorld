using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.MobileAppTheme;
using CoinGardenWorldMobileApp.MobileAppTheme.Extensions;
using CoinGardenWorldMobileApp.WebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Moved to CoinGardenWorldMobileApp.MobileAppTheme
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddMsalAuthentication(options =>
//{
//    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
//});
// CoinGardenWorldMobileApp.MobileAppTheme
builder.Services.AddMobileAppTheme(EnvironmentType.BLAZOR, builder.Configuration);


await builder.Build().RunAsync();
 