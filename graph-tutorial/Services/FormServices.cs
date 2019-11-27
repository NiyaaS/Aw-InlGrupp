using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using graph_tutorial.ViewModels;
using Microsoft.Graph;
using Microsoft.SharePoint.Client;

namespace graph_tutorial.Services
{
  public class FormServices
  {
    public static async Task<IGroupMembersCollectionWithReferencesPage> GetGroupUsers()
    {
      var graphClient = GraphHelper.GetAuthenticatedClient();
      return await graphClient.Groups["{f0ec948b-59fd-47d3-a39a-aeb551442877}"].Members
        .Request()
        .GetAsync();
    }
  }
}
