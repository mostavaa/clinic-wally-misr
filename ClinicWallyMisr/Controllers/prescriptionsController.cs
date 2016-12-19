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
    public class prescriptionsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        visitService _visitService = new visitService();


        // GET: prescriptions
        public ActionResult Index(Guid? id)
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
            var prescriptions = db.prescriptions.Where(o=>o.visitId==id).Include(p => p.visit);
            return View(prescriptions.ToList());
        }


        // GET: prescriptions/Create
        public ActionResult Create(Guid? id)
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

        // POST: prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,notes,visitId")] prescription prescription)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                prescription.id = Guid.NewGuid();
                db.prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = prescription.visitId });
            }
            visit visit = _visitService.get(prescription.visitId);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View(prescription);
        }

        // GET: prescriptions/Edit/5
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
            prescription prescription = db.prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,notes,visitId")] prescription prescription)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = prescription.visitId });
            }
            return View(prescription);
        }

        // GET: prescriptions/Delete/5
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
            prescription prescription = db.prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            prescription prescription = db.prescriptions.Find(id);
            Guid visitId = (Guid)prescription.visitId;

            db.prescriptions.Remove(prescription);
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
