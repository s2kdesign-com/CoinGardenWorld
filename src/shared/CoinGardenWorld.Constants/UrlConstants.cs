using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.Constants {
    public static class UrlConstants
    {
        public const string OfficialSite = "https://coingarden.world";

        public const string GardenBotSite = "https://bot.coingarden.world";

        public const string MobileAppSite = "https://app.coingarden.world";

        public const string MetaverseSite = "https://metaverse.coingarden.world";

        public const string CharitySite = "https://charity.coingarden.world";

        public const string NftStoreSite = "https://store.coingarden.world";

        public const string TokenSite = "https://token.coingarden.world";

        public const string Documentation = "https://docs.coingarden.world";

        public const string GithubRepo = "https://github.com/s2kdesign-com/CoinGardenWorld";

        public const string Changelog = "https://github.com/s2kdesign-com/CoinGardenWorld/releases";

        #region Social Networks 
        
        public const string FacebookPage = "https://www.facebook.com/CoinGarden.World";
        
        public const string TwitterPage = "#";

        public const string MeduimPage = "#";

        public const string DiscordChannel = "https://discord.gg/KZqFK3D4Mw";

        public const string YoutubeChannel = "https://www.youtube.com/@CoinGarden-World";

        #endregion


#if DEBUG
        // TODO: Add localhost urls
#else
        // TODO: Move the values for public site here
#endif
    }
}
