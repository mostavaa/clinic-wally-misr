using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicWallyMisr;

namespace ClinicWallyMisr.Controllers
{
    public class SpecializationsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: Specializations
        public ActionResult Index()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            var specializations = db.Specializations.Include(s => s.Job);
            return View(specializations.ToList());
        }

        // GET: Specializations/Details/5
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
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // GET: Specializations/Create
        public ActionResult Create()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.jobId = new SelectList(db.Jobs, "id", "name");
            return View();
        }

        // POST: Specializations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,jobId")] Specialization specialization)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                specialization.id = Guid.NewGuid();
                db.Specializations.Add(specialization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobId = new SelectList(db.Jobs, "id", "name", specialization.jobId);
            return View(specialization);
        }

        // GET: Specializations/Edit/5
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
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobId = new SelectList(db.Jobs, "id", "name", specialization.jobId);
            return View(specialization);
        }

        // POST: Specializations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,jobId")] Specialization specialization)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(specialization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobId = new SelectList(db.Jobs, "id", "name", specialization.jobId);
            return View(specialization);
        }

        // GET: Specializations/Delete/5
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
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: Specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            Specialization specialization = db.Specializations.Find(id);
            db.Specializations.Remove(specialization);
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
    }
}
