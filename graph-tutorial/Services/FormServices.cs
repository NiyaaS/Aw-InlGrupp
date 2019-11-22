using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using graph_tutorial.ViewModels;
using Microsoft.Graph;
using Microsoft.SharePoint.Client;
using ListItem = Microsoft.SharePoint.Client.ListItem;

namespace graph_tutorial.Services
{
  public class FormServices
  {
    public static async Task<IGroupMembersCollectionWithReferencesPage> GetUsersAsync()
    {
      var graphClient = GraphHelper.GetAuthenticatedClient();
      var members = await graphClient.Groups["f0ec948b-59fd-47d3-a39a-aeb551442877}"].Members 
        .Request()
        .Select("givenName,userPrincipalName")
        .GetAsync();

                         //<<<< Doesn't work !!!>>>> 

      //List<MembersCount> items = new List<MembersCount>();

      //if (members?.Count > 0)
      //{
      //  foreach (var user in members)
      //  {
      //    items.Add(new MembersCount
      //    {
      //      Properties = new Dictionary<string, object>
      //      {
      //        { Resource.Prop_upn, user.UserPrincipalName },
      //        { Resource.Prop_gn, user.GivenName }
      //      }
      //    });
      //  }
      //}
      return members;
    }


    public static UserCollection GetUsers()
    {
      var clientContext = CsomHelper.GetSpContext();
      var group = clientContext.Web.SiteGroups.GetByName("DevelopGrouper");
      clientContext.Load(group);

      var userCollection = group.Users;
      clientContext.Load(userCollection);
      clientContext.ExecuteQueryRetry();
      return userCollection;
    }
    
  }

}
