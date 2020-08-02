using System;
using System.Collections.Generic;
using System.Globalization;
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
            using (MyModel tw = new MyModel())
            {
                var events = tw.Calanders.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Calender cal)
        {
            var status = false;
            using (MyModel dc = new MyModel())
            {
                if (cal.SymptomID > 0)
                {
                    var v = dc.Calanders.Where(a => a.SymptomID == cal.SymptomID).FirstOrDefault();
                    if(v != null)
                    {
                        v.Subject = cal.Subject;
                        v.Description = cal.Description;
                        v.ThemeColour = cal.ThemeColour;
                    }
                }
                else
                {
                    dc.Calanders.Add(cal);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (MyModel dc = new MyModel())
            {
                var v = dc.Calanders.Where(a => a.SymptomID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Calanders.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}