using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace graph_tutorial.ViewModels
{
  public class MembersViewModel
  {
    public bool Selectable { get; set; }
    public IEnumerable<MembersCount> Items { get; set; }
    public MembersViewModel(bool selectable = true)
    {
      Selectable = selectable;
      Items = Enumerable.Empty<MembersCount>();
    }
  }
  public class MembersCount
  {
    public string Id { get; set; }
    public string UserPrincipalName { get; set; }
    public string GivenName { get; set; }

    public Dictionary<string, object> Properties;

    public MembersCount()
    {
      Properties = new Dictionary<string, object>();
    }
  }
}
