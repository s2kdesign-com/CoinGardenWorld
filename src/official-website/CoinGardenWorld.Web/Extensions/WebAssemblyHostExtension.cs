using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace CoinGardenWorld.Web.Extensions
{
    public static class WebAssemblyHostExtension
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {      
            var js = host.Services.GetRequiredService<IJSRuntime>();

            CultureInfo culture;
            var browserLanguage = await js.InvokeAsync<string>("getBrowserLanguage");
            var blazorCulture = await js.InvokeAsync<string>("blazorCulture.get");

            if (!string.IsNullOrEmpty(blazorCulture))
            {
                culture = new CultureInfo(blazorCulture);
            }
            else
            {
                culture = new CultureInfo(browserLanguage);
                await js.InvokeVoidAsync("blazorCulture.set", browserLanguage);
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
