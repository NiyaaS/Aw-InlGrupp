using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;

namespace graph_tutorial.ViewModels
{
  public class FieldValues
  {
    public string Title { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public FieldUserValue People { get; set; }

  }
}
