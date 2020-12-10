
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ASC.Online.AuctionApp.Auth.ApiServer
{
    public static class Config
    {
        private static string clientBaseUri = "localhost:4200";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
                //new IdentityResources.Address(),
                // new IdentityResource(
                //    "roles",
                //    "Your role(s)",
                //    new List<string>() { "role" })
            };



        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(
                    "OnlineAuctionSessionAPI",
                    "Online Auction API",new List<string>(){ "OnlineAuctionSessionAPI"}),
            };

        public static IEnumerable<Client> Clients =>

            new Client[]
            {              
               // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "auctionAppclient",
                    ClientName = "Auction App Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 3600,
                    AllowAccessTokensViaBrowser = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    SlidingRefreshTokenLifetime = 30,
                    AllowOfflineAccess = true,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AlwaysSendClientClaims = true,
                    Enabled = true,
                    AllowedScopes = { "openid", "profile", "offline_access",
                        "OnlineAuctionSessionAPI"},
                    PostLogoutRedirectUris = new List<string> {
                        $"http://{clientBaseUri}/"
                    },
                    RedirectUris = new List<string>
                    {
                        $"http://{clientBaseUri}/validate-refresh.html",
                        $"http://{clientBaseUri}/silent-refresh.html"
                    }

                }
            };
    }
}