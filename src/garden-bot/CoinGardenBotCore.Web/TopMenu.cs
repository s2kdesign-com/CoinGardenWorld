﻿using CoinGardenWorld.Theme.Models.Shared;
using Microsoft.Extensions.Localization;

namespace CoinGardenBotCore.Web {
    public class TopMenu : ITopMenu {
        private readonly IStringLocalizer<TopMenu> _localizer;
        public TopMenu(IStringLocalizer<TopMenu> localizer) {
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
                    Title = _localizer["Information"],
                    SubMenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = _localizer["Documentation"],
                            Url = CoinGardenWorld.Constants.UrlConstants.Documentation,
                            IsExternalUrl = true
                            
                        },
                        new MenuItem
                        {
                            Title = _localizer["Github"],
                            Url = CoinGardenWorld.Constants.UrlConstants.GithubRepo,
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
