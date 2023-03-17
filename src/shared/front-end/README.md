## CoinGarden.World.Theme

### How to use it 

1. Add `CoinGarden.World.Theme` NuGet package to your Blazor project 
2. Change `App.razor`: 
   - From: `<Router AppAssembly="@typeof(App).Assembly">`
   - To: `<Router AppAssembly="@typeof(App).Assembly" AdditionalAssemblies="new[]{typeof(CoinGardenWorld.Theme.ThemeJsInterop).Assembly}">`
3. Again Change
   - From: `DefaultLayout="@typeof(MainLayout)"` and `Layout="@typeof(MainLayout)"`
   - To: `DefaultLayout="@typeof(HomeLayout)"` and `Layout="@typeof(HomeLayout)"`

4. Add usings to `_Imports.razor`
   -  ```c#
		@using CoinGardenWorld.Theme.Pages
		@using CoinGardenWorld.Theme.Shared
		@using CoinGardenWorld.Theme.Components
		@using CoinGardenWorld.Theme.Components.HeaderBanners
		@using CoinGardenWorld.Theme.Components.FeatureCards
		@using CoinGardenWorld.Theme.Components.FeaturePanels
		```
5. Open Program.cs and add this lines before `await builder.Build().RunAsync();`
   - ```c#   
		builder.Services.AddCgwThemeExtensions();
		var host = builder.Build();
		await host.SetDefaultCulture();
		```
6. In Index.razor add `@inherits ThemeComponentBase<HomeBanner>`
7. In all other pages add `@inherits ThemeComponentBase<PageBanner>` 
8. Add in the `<head>` element `wwwroot/index.html` the css for the theme:
   - ```html		
		<link rel="stylesheet" href="./_content/CoinGardenWorld.Theme/assets/css/vendor.bundle.css?ver=210">
		<link rel="stylesheet" href="./_content/CoinGardenWorld.Theme/assets/css/style-zinnia.css?ver=210">
		<link href="./_content/CoinGardenWorld.Theme/lib/cryptofonts/cryptofont/cryptofont.css" rel="stylesheet" />
		<link rel="stylesheet" href="./_content/CoinGardenWorld.Theme/assets/css/theme.css?ver=210">
	   ```
9. Change the `<body>` element to: 
```html

<body class="nk-body body-wider mode-onepage bg-light">
<div id="app">
    <!-- preloader -->
    <div class="preloader preloader-alt no-split">
        <span class="spinner spinner-alt">
            <img class="spinner-brand" src="./images/preloader.png">
        </span>
    </div>
</div>
	<script src="_content/Microsoft.Authentication.WebAssembly.Msal/AuthenticationService.js"></script>
	<script src="_framework/blazor.webassembly.js"></script>
	<script>navigator.serviceWorker.register('service-worker.js');</script>
	<script src="./_content/CoinGardenWorld.Theme/assets/js/jquery.bundle.js?ver=210"></script>
</body>
```
10. If you used to create your project with authentication, remove:
   - `Shared/RedirectToLogin.razor` 
   - `Shared/LoginDisplay.razor`
   - `Shared/Authentication.razor`

### DONE