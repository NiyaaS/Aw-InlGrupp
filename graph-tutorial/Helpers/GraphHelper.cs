using Microsoft.Graph;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using graph_tutorial.TokenStorage;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System;
using graph_tutorial.ViewModels;

namespace graph_tutorial.Helpers
{
  public static class GraphHelper
  {
    private static string appId = ConfigurationManager.AppSettings["ida:AppId"];
    private static string appSecret = ConfigurationManager.AppSettings["ida:AppSecret"];
    private static string redirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];
    private static string graphScopes = ConfigurationManager.AppSettings["ida:AppScopes"];

    

    internal static GraphServiceClient GetAuthenticatedClient()
    {
      return new GraphServiceClient(
        new DelegateAuthenticationProvider(
          async (requestMessage) =>
          {
            var idClient = ConfidentialClientApplicationBuilder.Create(appId)
              .WithRedirectUri(redirectUri)
              .WithClientSecret(appSecret)
              .Build();

            var tokenStore = new SessionTokenStore(idClient.UserTokenCache,
              HttpContext.Current, ClaimsPrincipal.Current);

            var accounts = await idClient.GetAccountsAsync();

            var scopes = graphScopes.Split(' ');
            var result = await idClient.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
              .ExecuteAsync();

            requestMessage.Headers.Authorization =
              new AuthenticationHeaderValue("Bearer", result.AccessToken);
          }));
    }

    public static async Task<User> GetUserDetailsAsync(string accessToken)
    {
      var graphClient = new GraphServiceClient(
        new DelegateAuthenticationProvider(
          async (requestMessage) =>
          {
            requestMessage.Headers.Authorization =
              new AuthenticationHeaderValue("Bearer", accessToken);
          }));

      return await graphClient.Me.Request().GetAsync();
    }
  }
}
