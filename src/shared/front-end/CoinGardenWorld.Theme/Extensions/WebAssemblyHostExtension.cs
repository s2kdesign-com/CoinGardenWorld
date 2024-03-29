﻿using Microsoft.AspNetCore.Components;
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

        public static async Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var navigation = host.Services.GetRequiredService<NavigationManager>();
            var query = HttpUtility.ParseQueryString(new Uri(navigation.Uri).Query);

            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();

            CultureInfo? queryCulture = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                .ToList().FirstOrDefault(c => c.TwoLetterISOLanguageName == query[_queryParamName]);

            // If there is a query param , set the language to it
            if (queryCulture != null && CultureInfo.CurrentCulture.TwoLetterISOLanguageName != queryCulture.TwoLetterISOLanguageName)
            {
                await localStorage.SetItemAsync<string>("culture", queryCulture.Name);
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
                var js = host.Services.GetRequiredService<ThemeJsInterop>();
                var browserLanguage = await js.GetBrowserLanguage();
                setCulture = new CultureInfo(browserLanguage);
            }

            await localStorage.SetItemAsync<string>("culture", setCulture.Name);

            CultureInfo.DefaultThreadCurrentCulture = setCulture;
            CultureInfo.DefaultThreadCurrentUICulture = setCulture;
        }
    }

}
