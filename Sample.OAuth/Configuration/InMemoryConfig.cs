using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;



namespace Sample.OAuth.Configuration
{
    //Класс конфигруации IdentityServer4 в памяти
    public static class InMemoryConfig
    {
        //Ресурсы идентификации: представляют утверждения о пользователе
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
          new List<IdentityResource>
          {
              //Спецификация OpenID Connect  https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResource("roles", "User role(s)", new List<string> { "role" }),
          };

        //Области доступа, запрашиваемые клиентом
        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> { };

        //Организация имен областей
        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>{ };

        //Клиенты представляют приложения, которые могут запрашивать токены с сервера идентификации
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
               new Client
               {
                   ClientId = "blazorWASM",
                   AllowedGrantTypes = GrantTypes.Code,
                   RequirePkce = true,
                   RequireClientSecret = false,
                   AllowedCorsOrigins = { "https://localhost:5020" },
                   AllowedScopes =
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile
                   },
                   RedirectUris = { "https://localhost:5020/authentication/login-callback" },
                   PostLogoutRedirectUris = { "https://localhost:5020/authentication/logout-callback" }
               }
            };
    }
}
