using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using graph_tutorial.Helpers;
using Microsoft.SharePoint.Client;

namespace graph_tutorial.Services
{
  public class SpFxServices
  {
    public static ListItemCollection GetListData()
    {
      var clientContext = CsomHelper.GetSpContext();
      var list = clientContext.Web.Lists.GetByTitle("AwEvents");

      var query = CamlQuery.CreateAllItemsQuery(25);
      var items = list.GetItems(query);

      clientContext.Load(items);
      clientContext.ExecuteQuery();
      return items;
    }
  }
}
