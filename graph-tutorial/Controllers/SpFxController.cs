using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using graph_tutorial.Services;
using graph_tutorial.ViewModels;
using Microsoft.SharePoint.Client;


namespace graph_tutorial.Controllers
{
  public class SpFxController : BaseController
  {
    [Authorize]
    public ActionResult ListDetail()
    {
      var fieldData = SpFxServices.GetListData();
      return View(fieldData);
    }

    public ActionResult Error(string message, string debug)
    {
      Flash(message, debug);
      return RedirectToAction("ListDetail");
    }
  }
}
