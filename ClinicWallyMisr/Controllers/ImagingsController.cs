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
    public class ImagingsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        visitService _visitService = new visitService();
        // GET: Imagings
        public ActionResult Index(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            var imagings = db.Imagings.Where(v=>v.VisitId==id).Include(i => i.visit);
            return View(imagings.ToList());
        }



        // GET: Imagings/Create
        public ActionResult Create(Guid?id)
        {
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            visit visit = _visitService.get(id);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View();
        }

        // POST: Imagings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ImageDate,ImageCenter,TypeofImage,Site,Comments,ImageName,VisitId")] Imaging imaging)
        {
            if (ModelState.IsValid)
            {
                imaging.id = Guid.NewGuid();
                db.Imagings.Add(imaging);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = imaging.VisitId });
            }
            visit visit = _visitService.get(imaging.VisitId);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View(imaging);
        }

        // GET: Imagings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imaging imaging = db.Imagings.Find(id);
            if (imaging == null)
            {
                return HttpNotFound();
            }
            return View(imaging);
        }

        // POST: Imagings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ImageDate,ImageCenter,TypeofImage,Site,Comments,ImageName,VisitId")] Imaging imaging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imaging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = imaging.VisitId});
            }
            return View(imaging);
        }

        // GET: Imagings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imaging imaging = db.Imagings.Find(id);
            if (imaging == null)
            {
                return HttpNotFound();
            }
            return View(imaging);
        }

        // POST: Imagings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Imaging imaging = db.Imagings.Find(id);
            Guid visitId = (Guid)imaging.VisitId;
            db.Imagings.Remove(imaging);
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
        //TODO Image Viewer
    }
}
