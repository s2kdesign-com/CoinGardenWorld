﻿using CoinGardenBotCore.Web.Localization;
using CoinGardenWorld.Theme.Models.Shared;
using Microsoft.Extensions.Localization;

namespace CoinGardenBotCore.Web {
    public class TopMenu : ITopMenu {
        public TopMenu() {

            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = TopMenu_Resource.Home,
                    Url = "#header"
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
