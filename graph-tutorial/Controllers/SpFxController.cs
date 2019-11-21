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
    // GET: SpFx
    [Authorize]
    public ActionResult ListDetail()
    {
      var fieldData = SpFxServices.GetListData();
      return View(fieldData);
    }
  }
}
