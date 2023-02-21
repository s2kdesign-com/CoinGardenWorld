using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.Theme.Components.HeaderBanners
{
    public partial class BannerBase : ComponentBase
    {

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }
    }
}
