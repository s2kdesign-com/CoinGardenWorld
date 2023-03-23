using CoinGardenWorld.Theme.Models.Shared;
using CoinGardenWorld.Web.Localization;
using Microsoft.Extensions.Localization;

namespace CoinGardenWorld.Web {
    public class TopMenu : ITopMenu
    {
        public TopMenu()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = TopMenu_Resource.Home,
                    Url = "#header"
                },
                new MenuItem
                {
                    Title = TopMenu_Resource.Application,
                    Url = "#mobile-app-home"
                },
                new MenuItem
                {
                    Title = TopMenu_Resource.Metaverse,
                    Url = "#metaverse-home"
                },
                new MenuItem
                {
                    Title = TopMenu_Resource.Token,
                    Url = "#token-home"
                },
                new MenuItem
                {
                    Title = TopMenu_Resource.Information,
                    SubMenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = TopMenu_Resource.Documentation,
                            Url = CoinGardenWorld.Constants.UrlConstants.Documentation,
                            IsExternalUrl = true
                        },
                        new MenuItem
                        {
                            Title = TopMenu_Resource.Github,
                            Url = CoinGardenWorld.Constants.UrlConstants.GithubRepo,
                            IsExternalUrl = true
                        },
                        new MenuItem
                        {
                            Title = TopMenu_Resource.Litepaper,
                            Url = "#"
                        }
                    }
                }
            };
        }

        public List<MenuItem> MenuItems { get; set; } 
    }
}
