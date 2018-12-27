using ActionFilterClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFiltersClass.Controllers
{
    [Layout]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewConfirmed()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(db.GetAll(Status.Confirmed));
        }
        public ActionResult ViewPending()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(db.GetAll(Status.Pending));
        }
        public ActionResult ViewRefused()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
         
            return View(db.GetAll(Status.Refused));
        }
        public ActionResult AddCandidate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            db.AddCandidate(candidate);
            return Redirect("/home/ViewPending");
        }
       [HttpPost]
        public void UpdateConfirmed(int id)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
           var candidate= db.GetCandidate(id);
            candidate.Status = Status.Confirmed;
            db.UpdateStatusForCandidate(candidate);
          
        }
        [HttpPost]
        public void UpdateRefused(int id)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            var candidate = db.GetCandidate(id);
            candidate.Status = Status.Refused;
            db.UpdateStatusForCandidate(candidate);

        }
        public ActionResult ViewDetails(int id)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(db.GetCandidate(id));
        }

        public ActionResult GetCount()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return Json(db.GetCount(Status.Refused), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetConfirmedCount()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return Json(db.GetCount(Status.Confirmed), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPendingCount()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return Json(db.GetCount(Status.Pending), JsonRequestBehavior.AllowGet);
        }
    }
}