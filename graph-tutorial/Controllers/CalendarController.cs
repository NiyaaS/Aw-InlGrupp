using graph_tutorial.Helpers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using graph_tutorial.Services;

namespace graph_tutorial.Controllers
{
    public class CalendarController : BaseController
    {
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var users = await FormServices.GetGroupUsers();
            var events = await CalendarServices.GetEventsAsync();

            foreach (var ev in events)
            {
                ev.Start.DateTime = DateTime.Parse(ev.Start.DateTime).ToLocalTime().ToString();
                ev.Start.TimeZone = TimeZoneInfo.Local.Id;
                ev.End.DateTime = DateTime.Parse(ev.End.DateTime).ToLocalTime().ToString();
                ev.End.TimeZone = TimeZoneInfo.Local.Id;
            }
            return View(events);
        }

        public ActionResult Error(string message, string debug)
        {
          Flash(message, debug);
          return RedirectToAction("Index");
        }
  }
}
