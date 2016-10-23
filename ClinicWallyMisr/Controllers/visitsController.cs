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
    public class visitsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        patientService _patientService = new patientService();
        ComplaintService _ComplaintService = new ComplaintService();
        // GET: visits
        public ActionResult Index(Guid? id)
        {
            if (id == null)
                return HttpNotFound();

        patient patient =  _patientService.get(id);
        if (patient == null)
            return HttpNotFound();

            var visits = db.visits.Where(d=>d.patientId==patient.id).Include(v => v.patient).Include(v => v.SystemPerson);
            ViewBag.patient = patient;
            return View(visits.ToList());
        }

        // GET: visits/Details/5
        /*
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }
        */
        // GET: visits/Create
        public ActionResult Create(Guid? id)
        {
            if (id == null)
                return HttpNotFound();

            patient patient = _patientService.get(id);
            if (patient == null)
                return HttpNotFound();
            ViewBag.patient = patient;

            ViewBag.DoctorId = new SelectList(db.SystemPersons.Where(o => o.Job.name.ToLower() == "doctor"), "id", "name");
            return View();
        }

        // POST: visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,visitDate,visitStatus,visitSite,complaintType,PresentHistory,decision,requestedInvestigations,GeneralAppearance,mentality,Built,Pallor,jaundice,cyanosis,postureDuringWalking,postureStanding,postureSitting,postureLyingSupineorPhone,vitalSigns,DoctorId,patientId")] visit visit)
        {
            if (ModelState.IsValid)
            {
                visit.id = Guid.NewGuid();
                db.visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index",new { @id=visit.patientId});
            }

            if (visit.patientId == null)
                return HttpNotFound();

            patient patient = _patientService.get(visit.patientId);
            if (patient == null)
                return HttpNotFound();
            ViewBag.patient = patient;
            ViewBag.DoctorId = new SelectList(db.SystemPersons.Where(o => o.Job.name.ToLower() == "doctor"), "id", "name", visit.DoctorId);
            return View(visit);
        }

        // GET: visits/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.SystemPersons.Where(o => o.Job.name.ToLower() == "doctor"), "id", "name", visit.DoctorId);
            return View(visit);
        }

        // POST: visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,visitDate,visitStatus,visitSite,complaintType,PresentHistory,decision,requestedInvestigations,GeneralAppearance,mentality,Built,Pallor,jaundice,cyanosis,postureDuringWalking,postureStanding,postureSitting,postureLyingSupineorPhone,vitalSigns,DoctorId,patientId")] visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { @id=visit.patientId});
            }
            ViewBag.DoctorId = new SelectList(db.SystemPersons.Where(o => o.Job.name.ToLower() == "doctor"), "id", "name", visit.DoctorId);
            return View(visit);
        }

        // GET: visits/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            visit visit = db.visits.Find(id);
            Guid patientId = (Guid)visit.patientId;
            db.visits.Remove(visit);
            db.SaveChanges();
            return RedirectToAction("Index", new { @id = patientId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void RemoveComplaint(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return;
            Complaint com = _ComplaintService.get(id);
            if (com != null)
            {
                _ComplaintService.delete(com);
                Response.Write("1");
            }
        }
        public void AddComplaint(string name, Guid? id)
        {
            if (name != string.Empty && name != null && id != null && id != Guid.Empty)
            {
                Complaint com = new Complaint() { id = Guid.NewGuid(), complaintName = name , visitId=id };
                _ComplaintService.add(com);
                Response.Write("1");
            }
            else Response.Write("9");
        }
    }
}
