using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using graph_tutorial.Helpers;
using graph_tutorial.Services;
using graph_tutorial.ViewModels;

namespace graph_tutorial.Controllers
{
  public class HomeController : BaseController
  {

    public async Task<ActionResult> Index()
    {
      var viewModel = new ResultsViewModel {Items = await HomeServices.GetMyPhoto()};
      return View(viewModel);
    }

    public ActionResult Error(string message, string debug)
    {
      Flash(message, debug);
      return RedirectToAction("Index");
    }
  }
}
