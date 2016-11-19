using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicWallyMisr;
using System.Web.Script.Serialization;

namespace ClinicWallyMisr.Controllers
{
    public class JobsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: Jobs
        public ActionResult Index()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Job job)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                job.id = Guid.NewGuid();
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Job job)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void findJobSpecilizations(Guid jobId)
        {
            if (jobId == null)
                return;
            JobService _jobService = new JobService();
           var records =  _jobService.get(jobId).Specializations.Select(o=> new { id = o.id , name = o.name}).ToList();
           Response.Write(new JavaScriptSerializer().Serialize(Json(records, JsonRequestBehavior.AllowGet)));
        }

    }
}
