using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using Microsoft.Graph;

namespace graph_tutorial.Services
{
  public class CalendarServices
  {
    public static async Task<IEnumerable<Event>> GetEventsAsync()

    {
      var graphClient = GraphHelper.GetAuthenticatedClient();

      var events = await graphClient.Me.Events.Request()
        .Select("subject,organizer,start,end")
        .OrderBy("createdDateTime DESC")
        .GetAsync();

      return events.CurrentPage;
    }
  }
}
