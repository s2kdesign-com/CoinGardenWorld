using CoinGardenWorld.Theme.Extensions;
using CoinGardenWorld.Theme.Models.Shared;
using CoinGardenWorldStore.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Singleton with the top menu implementation 
// TODO: Move this to Theme library - you can scan the entry assembly for classes that implement ITopMenu
builder.Services.AddSingleton<ITopMenu, TopMenu>();

// CoinGardenWorld.Theme
await builder.AddCgwHttpClientExtensions();


// CoinGardenWorld.Theme
builder.Services.AddCgwThemeExtensions();

var host = builder.Build();

// Extension method
await host.SetDefaultCulture();

await builder.Build().RunAsync();
