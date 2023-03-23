using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinGardenWorld.IdentityServer.Pages.Home;

[AllowAnonymous]
public class Index : PageModel
{
    public string Version;
    public string ProductVersion;
        
    public void OnGet()
    {
        Version = typeof(Duende.IdentityServer.Hosting.IdentityServerMiddleware).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+').First();


        var productVersion = Assembly.GetExecutingAssembly().GetName().Version;
        if (productVersion != null)
            ProductVersion = productVersion.ToString();
    }
}