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
    public class examinationsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
               visitService _visitService = new visitService();
        // GET: examinations
        public ActionResult Index(Guid? id)
        {
            if (id == null)
                return HttpNotFound();
            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            var examinations = db.examinations.Where(v => v.visitId == id).Include(e => e.visit);
            return View(examinations.ToList());
        }


        // GET: examinations/Create
        public ActionResult Create(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View();
        }

        // POST: examinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(examination examination)
        {
            if (ModelState.IsValid)
            {
                examination.id = Guid.NewGuid();
                db.examinations.Add(examination);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = examination.visitId });
            }
            if (examination.visitId == null)
                return HttpNotFound();

            visit visit = _visitService.get(examination.visitId);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View(examination);
        }


        // GET: examinations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examination examination = db.examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: examinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = examination.visitId });
            }
            return View(examination);
        }

        // GET: examinations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examination examination = db.examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: examinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            examination examination = db.examinations.Find(id);
            Guid visitId = (Guid)examination.visitId;
            db.examinations.Remove(examination);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = visitId });
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
