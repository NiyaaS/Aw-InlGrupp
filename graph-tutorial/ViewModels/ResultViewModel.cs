using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace graph_tutorial.ViewModels
{
  public class ResultsItem
  {
    public string Id { get; set; }
    public string Display { get; set; }
    public Dictionary<string, object> Properties;

    public ResultsItem()
    {
      Properties = new Dictionary<string, object>();
    }
  }

  public class ResultsViewModel
  {
    public bool Selectable { get; set; }
    public IEnumerable<ResultsItem> Items { get; set; }
    public ResultsViewModel(bool selectable = true)
    {
      Selectable = selectable;
      Items = Enumerable.Empty<ResultsItem>();
    }
  }
}
