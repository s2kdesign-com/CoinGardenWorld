using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;

namespace CoinGardenWorld.Theme.Extensions {
    public static class WebAssemblyHostExtension
    {
        private static string _queryParamName = "language";

        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var navigation = host.Services.GetRequiredService<NavigationManager>();
            var query = HttpUtility.ParseQueryString(new Uri(navigation.Uri).Query);

            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();

            CultureInfo? queryCulture = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                .ToList().FirstOrDefault(c => c.TwoLetterISOLanguageName == query[_queryParamName]);

            // If there is a query param , set the language it
            if (queryCulture != null && CultureInfo.CurrentCulture.TwoLetterISOLanguageName != queryCulture.TwoLetterISOLanguageName)
            {
                localStorage.SetItemAsync<string>("culture", queryCulture.Name);
                CultureInfo.DefaultThreadCurrentCulture = queryCulture;
                CultureInfo.DefaultThreadCurrentUICulture = queryCulture;
                return;
            }

            // Check if there is a local storage with language
            var cultureString = await localStorage.GetItemAsync<string>("culture");
            CultureInfo setCulture;
            if (!string.IsNullOrWhiteSpace(cultureString)) {
                setCulture = new CultureInfo(cultureString);
            }
            else {
                // First time opening the site, set the language to browser default
                var js = host.Services.GetRequiredService<IJSRuntime>();
                var browserLanguage = await js.InvokeAsync<string>("getBrowserLanguage");
                setCulture = new CultureInfo(browserLanguage);
            }

            localStorage.SetItemAsync<string>("culture", setCulture.Name);

            CultureInfo.DefaultThreadCurrentCulture = setCulture;
            CultureInfo.DefaultThreadCurrentUICulture = setCulture;
        }
    }
}
