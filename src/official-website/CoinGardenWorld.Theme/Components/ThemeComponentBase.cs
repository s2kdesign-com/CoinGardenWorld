using CoinGardenWorld.Theme.Components.HeaderBanners;
using CoinGardenWorld.Theme.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.Theme.Components
{

    public partial class ThemeComponentBase<TBanner> : ComponentBase where TBanner : BannerBase
    {
        [Inject] 
        protected IJSRuntime JSRuntime { get; set; } = default!;

        //[AutoInject] protected IStringLocalizer<AppStrings> Localizer = default!;

        protected virtual string BannerTitle { get; set; } = "Home";
        protected virtual string BannerDescription { get; set; } = " ";

        [CascadingParameter]
        public HomeLayout HomeLayout { get; set; } = default!;

        private IJSObjectReference? themeModule;

        

        private RenderFragment AddContent() => builder =>
        {
            builder.OpenComponent(0, typeof(TBanner));

            builder.AddAttribute(1, "Title", BannerTitle);
            builder.AddAttribute(1, "Description", BannerDescription);
            builder.CloseComponent();
        };


        protected sealed override async Task OnInitializedAsync()
        {
            try
            {

                await base.OnInitializedAsync();
                HomeLayout.Banner = AddContent();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                //ExceptionHandler.Handle(exp);
            }
        }

        protected sealed override async Task OnParametersSetAsync()
        {
            try
            {
                await base.OnParametersSetAsync();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                //ExceptionHandler.Handle(exp);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    await base.OnAfterRenderAsync(firstRender);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    //ExceptionHandler.Handle(exp);
                }
            }

            await base.OnAfterRenderAsync(firstRender);

            // Theme initialization
            if (themeModule is null)
            {
                // Theme initialization
                themeModule = await JSRuntime.InvokeAsync<IJSInProcessObjectReference>(
                    "import", "./_content/CoinGardenWorld.Theme/assets/js/scripts.js");

            }
            await themeModule.InvokeAsync<string>("NioApp.winLoad");
        }


    }
}
