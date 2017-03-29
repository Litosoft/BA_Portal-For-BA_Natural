using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;

namespace BA_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
        
        /*
        public ActionResult Backend()
        {
            return new Dpm().CallBack(this);
        }

        
        class Dpm : DayPilotMonth
        {

            protected override void OnInit(InitArgs e)
            {
                var db = new DataClasses1DataContext();
                Events = from ev in db.events select ev;

                DataIdField = "id";
                DataTextField = "text";
                DataStartField = "eventstart";
                DataEndField = "eventend";

                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                var toBeResized = (from ev in db.Events where ev.id == Convert.ToInt32(e.Id) select ev).First();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SubmitChanges();
                Update();
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                var toBeResized = (from ev in db.Events where ev.id == Convert.ToInt32(e.Id) select ev).First();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SubmitChanges();
                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                var toBeCreated = new Event { eventstart = e.Start, eventend = e.End, text = (string)e.Data["name"] };
                db.Events.InsertOnSubmit(toBeCreated);
                db.SubmitChanges();
                Update();
            }
        }
        */
        
    }
}