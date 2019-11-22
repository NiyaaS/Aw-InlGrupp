using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using graph_tutorial.Services;

namespace graph_tutorial.Controllers
{
  public class HomeController : BaseController
  {
    public ActionResult Index()
    {
      return View();
    }


    public ActionResult About()
    {
      var users = FormServices.GetUsersAsync();
      return View(users);
    }


    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    public ActionResult Error(string message, string debug)
    {
      Flash(message, debug);
      return RedirectToAction("Index");
    }
  }
}
