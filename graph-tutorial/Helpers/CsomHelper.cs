using System.Configuration;
using Microsoft.SharePoint.Client;
using AuthenticationManager = OfficeDevPnP.Core.AuthenticationManager;



namespace graph_tutorial.Helpers
{
    public class CsomHelper
    {
    public static ClientContext GetSpContext()
    {
      var context = new AuthenticationManager();
      return context.GetSharePointOnlineAuthenticatedContextTenant(
        ConfigurationManager.AppSettings["ida:SpUrl"],
        ConfigurationManager.AppSettings["ida:SpTenant"],
        ConfigurationManager.AppSettings["ida:SpPassword"]);
    }
  }
}
