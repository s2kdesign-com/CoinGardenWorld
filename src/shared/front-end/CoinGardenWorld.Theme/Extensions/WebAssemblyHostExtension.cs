using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.Theme.Extensions {
    public static class WebAssemblyHostExtension
    {
        private static string _queryParamName = "language";

        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var navigation = host.Services.GetRequiredService<NavigationManager>();


            var query = HttpUtility.ParseQueryString(new Uri(navigation.Uri).Query);

            var cultureInfo = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                .ToList().FirstOrDefault(c => c.TwoLetterISOLanguageName == query[_queryParamName]);

            CultureInfo culture;
            if (cultureInfo != null && CultureInfo.CurrentCulture.TwoLetterISOLanguageName != cultureInfo.TwoLetterISOLanguageName)
            {
                culture = cultureInfo;
            }
            else
            {
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
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

        }
    }
}
