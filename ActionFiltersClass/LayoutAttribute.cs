using ActionFilterClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFiltersClass
{
    public class LayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            filterContext.Controller.ViewBag.CounterforConfirmed = db.GetCount(Status.Confirmed);
            filterContext.Controller.ViewBag.CounterforRefused = db.GetCount(Status.Refused);
            filterContext.Controller.ViewBag.CounterforPending = db.GetCount(Status.Pending);
            base.OnActionExecuted(filterContext);
        }
    }
}