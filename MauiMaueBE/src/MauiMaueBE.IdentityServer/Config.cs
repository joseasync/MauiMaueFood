using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MauiMaueBE.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope(name: "api1", displayName: "MyAPI") 
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "mauimaueconsole",
                ClientName = "App MauiMaue Console Test",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, //Change it for real usage
                AllowedScopes = new List<string> {"api1"}
            },
            // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) }, //Change it for real usage
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5002/signin-oidc" }, // where to redirect to after login
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" }, // where to redirect to after logout
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            // MauiMaueFood.Client
            new Client
            {
                ClientId = "mauimauefood.appclient",
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) }, //Change it for real usage
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "mauimauefoodclient://" }, // where to redirect to after login
                PostLogoutRedirectUris = { "mauimauefoodclient://" }, // where to redirect to after logout
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1" 
                }
            }
        };
}