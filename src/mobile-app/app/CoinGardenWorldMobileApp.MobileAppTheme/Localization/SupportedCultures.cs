using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Localization
{
    public static class SupportedCultures
    {
        public static Dictionary<CultureInfo, string> Cultures = new Dictionary<CultureInfo, string>
        {
            { new CultureInfo("en-US"), "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/Flag_of_the_United_States.svg/320px-Flag_of_the_United_States.svg.png"},
            { new CultureInfo("bg-BG"), "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Flag_of_Bulgaria.svg/320px-Flag_of_Bulgaria.svg.png"}
        };
    }
}
