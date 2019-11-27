using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using graph_tutorial.ViewModels;

namespace graph_tutorial.Services
{
  public class HomeServices
  {
    public static async Task<List<ResultsItem>> GetMyPhoto()
    {
      var graphClient = GraphHelper.GetAuthenticatedClient();
      var items = new List<ResultsItem>();

      try
      {
        using (var photo = await graphClient.Me.Photo.Content.Request().GetAsync())
        {
          if (photo != null)
          {
            using (BinaryReader reader = new BinaryReader(photo))
            {
              byte[] data = reader.ReadBytes((int)photo.Length);
              items.Add(new ResultsItem
              {
                Properties = new Dictionary<string, object>
                {
                  { "Stream", data }
                }
              });
            }
          }
          else
          {
            return null;
          }
        }
      }
      catch (Exception e)
      {
        //e.Message;
      }
      return items;
    }
  }
}
