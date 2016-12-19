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
    public class EndoscopiesController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        visitService _visitService = new visitService();
        // GET: Endoscopies
        public ActionResult Index(Guid?id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            var endoscopies = db.Endoscopies.Where(o=>o.visitId==id).Include(e => e.visit);
            return View(endoscopies.ToList());
        }

        // GET: Endoscopies/Create
        public ActionResult Create(Guid?id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View();
        }

        // POST: Endoscopies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Endoscopy1,EndoscopyType,site,comments,graph,visitId")] Endoscopy endoscopy)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                endoscopy.id = Guid.NewGuid();
                db.Endoscopies.Add(endoscopy);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = endoscopy.visitId });
            }
            visit visit = _visitService.get(endoscopy.visitId);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View(endoscopy);
        }

        // GET: Endoscopies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endoscopy endoscopy = db.Endoscopies.Find(id);
            if (endoscopy == null)
            {
                return HttpNotFound();
            }
            return View(endoscopy);
        }

        // POST: Endoscopies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Endoscopy1,EndoscopyType,site,comments,graph,visitId")] Endoscopy endoscopy)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                db.Entry(endoscopy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = endoscopy.visitId});
            }
            return View(endoscopy);
        }

        // GET: Endoscopies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endoscopy endoscopy = db.Endoscopies.Find(id);
            if (endoscopy == null)
            {
                return HttpNotFound();
            }
            return View(endoscopy);
        }

        // POST: Endoscopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            Endoscopy endoscopy = db.Endoscopies.Find(id);
            Guid visitId = (Guid)endoscopy.visitId;
            db.Endoscopies.Remove(endoscopy);
            db.SaveChanges();
            return RedirectToAction("Index", new { @id = visitId });
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
