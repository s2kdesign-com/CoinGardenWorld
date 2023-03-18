using CoinGardenWorld.Theme.Models.Shared;
using Microsoft.Extensions.Localization;

namespace CoinGardenWorld.Web {
    public class TopMenu : ITopMenu
    {
        private readonly IStringLocalizer<TopMenu> _localizer;
        public TopMenu(IStringLocalizer<TopMenu> localizer)
        {
            _localizer = localizer;

            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = _localizer["Home"],
                    Url = "#header"
                },
                new MenuItem
                {
                    Title = _localizer["Application"],
                    Url = "#mobile-app-home"
                },
                new MenuItem
                {
                    Title = _localizer["Metaverse"],
                    Url = "#metaverse-home"
                },
                new MenuItem
                {
                    Title = _localizer["Token"],
                    Url = "#token-home"
                },
                new MenuItem
                {
                    Title = _localizer["Information"],
                    SubMenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = _localizer["Documentation"],
                            Url = "https://docs.coingarden.world/",
                            IsExternalUrl = true
                        },
                        new MenuItem
                        {
                            Title = _localizer["Github"],
                            Url = "https://github.com/s2kdesign-com/CoinGardenWorld/",
                            IsExternalUrl = true
                        },
                        new MenuItem
                        {
                            Title = _localizer["Litepaper"],
                            Url = "#"
                        }
                    }
                }
            };
        }

        public List<MenuItem> MenuItems { get; set; } 
    }
}
