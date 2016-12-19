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
    public class medicinesController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: medicines
        public ActionResult Index(Guid? id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            prescription presc =  db.prescriptions.FirstOrDefault(i => i.id == id);
            if (presc == null)
                return HttpNotFound();
            ViewBag.prescription = presc;
            ViewBag.visit = presc.visit;
            return View(db.medicines.Where(o=>o.prescriptionId==id).ToList());
        }



        // GET: medicines/Create
        public ActionResult Create(Guid?id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || id == Guid.Empty)
                return HttpNotFound();
            prescription presc = db.prescriptions.FirstOrDefault(i => i.id == id);
            if (presc == null)
                return HttpNotFound();
            ViewBag.prescription = presc;
            return View();
        }

        // POST: medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( medicine medicine)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                medicine.id = Guid.NewGuid();
                db.medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = medicine.prescriptionId });
            }
            prescription presc = db.prescriptions.FirstOrDefault(i => i.id == medicine.prescriptionId);
            if (presc == null)
                return HttpNotFound();
            ViewBag.prescription = presc;
            return View(medicine);
        }

        // GET: medicines/Edit/5
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
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(medicine medicine)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = medicine.prescriptionId });
            }
            return View(medicine);
        }

        // GET: medicines/Delete/5
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
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            medicine medicine = db.medicines.Find(id);
            Guid prescId = (Guid)medicine.prescriptionId;

            db.medicines.Remove(medicine);
            db.SaveChanges();
            return RedirectToAction("Index", new { @id = prescId });
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
