using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using graph_tutorial.Helpers;
using graph_tutorial.Services;
using graph_tutorial.ViewModels;
using Microsoft.SharePoint.Client;

namespace graph_tutorial.Controllers
{
  public class FormController : BaseController
  {
    [HttpGet]
    [Authorize]
    public ActionResult SetListDetail()
    {
      var model = new CreateNewItems();
      return View(model);
    }

    [HttpPost]
    [Authorize]
    //[ValidateAntiForgeryToken]
    public ActionResult SetListDetail(CreateNewItems model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      var clientContext = CsomHelper.GetSpContext();
      var userCollection = FormServices.GetUsers();
      var list = clientContext.Web.Lists.GetByTitle("AwEvents");

      var itemCreateInfo = new ListItemCreationInformation();
      var fieldData = list.AddItem(itemCreateInfo);

      fieldData["Title"] = model.Title;
      fieldData["Time"] = model.Time;
      fieldData["Description"] = model.Description;
      fieldData["Adress"] = model.Address;
      foreach (var user in userCollection)
      {
        fieldData["Attending"] = user.Email;
      }

      fieldData.Update();
      clientContext.ExecuteQueryRetry();

      return RedirectToAction("Index", "Home");
    }
  }
}
