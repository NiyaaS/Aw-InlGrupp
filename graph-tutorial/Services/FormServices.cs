using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using Microsoft.Graph;
using ListItem = Microsoft.SharePoint.Client.ListItem;

namespace graph_tutorial.Services
{
  public class FormServices
  {
    public static async Task<Microsoft.Graph.ListItem[]> GetListAsync()
    {
      var graphClient = GraphHelper.GetAuthenticatedClient();

      // Site Guid---> b88ff750-937d-40aa-a69b-eb2ff4eedb2b | List Guid--> 257874ec-3c52-4e4d-852d-3e57e9cab4cd | Title Columns Guid--> fa564e0f-0c70-4ab9-b863-0177e6ddd247

      var listItem = new Microsoft.Graph.ListItem();


      await graphClient.Sites["{b88ff750-937d-40aa-a69b-eb2ff4eedb2b}"].Lists["{257874ec-3c52-4e4d-852d-3e57e9cab4cd}"].Items
        .Request()
        .AddAsync(listItem);

      return new []{ listItem };
    }


 
    //public static ListItem SetListItems()
    //{
    //  var clientContext = CsomHelper.GetSpContext();
    //  var list = clientContext.Web.Lists.GetByTitle("AwEvents");
    //  var itemCreateInfo = new ListItemCreationInformation();
    //  var oListItem = list.AddItem(itemCreateInfo);

    //  oListItem.Update();
    //  clientContext.ExecuteQuery();
    //  return oListItem;

    //}
  }
}
