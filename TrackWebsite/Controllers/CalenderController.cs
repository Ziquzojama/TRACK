using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackWebsite.Model;

namespace TrackWebsite.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using ( MyModel tw = new MyModel())
            {
                var events = tw.Calanders.ToList();
                return new JsonResult { Data = events,JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}