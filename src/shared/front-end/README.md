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
5. Open Program.cs and add: 
	- after `builder.RootComponents.Add<HeadOutlet>("head::after");`
	   - ```c#
			builder.Services.AddSingleton<ITopMenu, TopMenu>();
	     ```
	- before `builder.Services.AddMsalAuthentication` or just add it with the other one if you don`t have authentication
	   - ```c# 	   
			var externalApisConfig = new ExternalApisSettings();
			builder.Configuration.Bind(externalApisConfig);
			await builder.AddCgwHttpClientExtensions(externalApisConfig);
	     ```
	- before `await builder.Build().RunAsync();`
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
10. Delete all files in `Shared` folder like `MainLayout.razor` and `NavMenu.razor` 
10. If you used to create your project with authentication, remove:
   - `Shared/RedirectToLogin.razor` 
   - `Shared/LoginDisplay.razor`
   - `Shared/Authentication.razor`

### DONE

### Little extra: 
#### 1. Multilingual support
If you want to add Multilingual support, just add folder `Localization` and resource `TopMenu.bg.resx` TopMenu.{LanguangeTwoLetterIsoName}.resx
#### 2. Provide "Update Now" UI and feature to your Blazor PWA that appears when the next version of one is available.
More info: https://github.com/jsakamoto/Toolbelt.Blazor.PWA.Updater
1. Modify the "service-worker.published.js" file
```js
// 👇 Add these line to accept the message from this library.
self.addEventListener('message', event => { 
  if (event.data?.type === 'SKIP_WAITING') self.skipWaiting();
});
```
2. Modify the "index.html" file
```html
  <!-- 👇 Remove this script, and...
  <script>navigator.serviceWorker.register('service-worker.js');</script> -->

  <!-- 👇 add this script element instead. -->
  <script src="_content/Toolbelt.Blazor.PWA.Updater.Service/script.min.js"></script>
  ```