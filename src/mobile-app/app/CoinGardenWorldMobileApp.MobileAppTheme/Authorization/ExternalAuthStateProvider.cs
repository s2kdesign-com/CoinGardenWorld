using System.Security.Claims;
using CoinGardenWorldMobileApp.MobileAppTheme.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Authorization
{
    public class ExternalAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationService _authenticationService;
        private ClaimsPrincipal _currentUser;

        public ExternalAuthStateProvider(IAuthenticationService authenticationService)
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            _authenticationService = authenticationService;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            Task.FromResult(new AuthenticationState(_currentUser));

        public Task LogInAsync()
        {
            var loginTask = LogInAsyncCore();
            // Use BlazorWebView to update the auth state
            NotifyAuthenticationStateChanged(loginTask);

            return loginTask;

            async Task<AuthenticationState> LogInAsyncCore()
            {
                _currentUser = await LoginWithExternalProviderAsync();

                return new AuthenticationState(_currentUser);
            }
        }

        private async Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
        {
            var authResult = await _authenticationService.AcquireTokenInteractiveAsync();

            // Authentication failed, return the current logged out user state
            if (authResult == null) return _currentUser;

            List<Claim> claims;
            ClaimsPrincipal authenticatedUser;

            // For some reason AAD sets "name" as the claim type for the user name and not ClaimsType.Name...
            // This is a workaround since context.User.Identity only recognizes ClaimsType.Name
            var name = authResult.ClaimsPrincipal.FindFirst(c => c.Type == "name")?.Value;
            if (name != null)
            {
                claims = claims = authResult.ClaimsPrincipal.Claims.ToList();
                claims.Add(new Claim(ClaimTypes.Name, name));
                authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims));
            }
            else
            {
                // Another interesting quirk, we MUST recreate the ClaimsPrincipal instead of using authResult.ClaimsPrincipal directly
                // according to https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/security/?view=aspnetcore-6.0&pivots=maui
                authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(authResult.ClaimsPrincipal.Claims));
            }

            // Here's the access token
            var token = authResult.AccessToken;

            return await Task.FromResult(authenticatedUser);
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}
