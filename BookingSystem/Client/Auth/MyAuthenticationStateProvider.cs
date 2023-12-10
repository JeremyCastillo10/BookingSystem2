
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BookingSystem.Client.Auth
{
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public MyAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userClaims = new List<Claim>();

            if (IsUserLoggedIn())
            {
                // Retrieve user claims from storage or API
                var claimsIdentity = new ClaimsIdentity(userClaims, "MyAuthenticationScheme");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            else
            {
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            }
        }


        private bool IsUserLoggedIn()
        {
            // Check if user is logged in based on storage or API response
            return true; // Replace with actual logic
        }

        private void SaveUserClaims(IEnumerable<Claim> claims)
        {
            // Save user claims to storage or API
            // ...
        }
    }

}
