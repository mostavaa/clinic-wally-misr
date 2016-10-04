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
    public class patientsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: patients
        public ActionResult Index()
        {
            var patients = db.patients.Include(p => p.SystemPerson);

            if (Request.QueryString["name"] != null && Request.QueryString["name"] != string.Empty)
            {
                patients = patients.Where(o => o.name.ToLower().Contains(Request.QueryString["name"]));
            }
            return View(patients.ToList());
        }

        // GET: patients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: patients/Create
        public ActionResult Create()
        {
            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name");
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,diagnosis,diagnosisCode,notes,masterStatus,dateofDiagnosis,firstStatus,dateofRelapse,firstPresentationDate,birthDate,doctorId,age,gender,referredFrom,education,nationality,maritalStatus,occupation,noofChildren,ageofOldest,ageofYoungest,phone1,phone2,phone3,email,governorate,address,relationName,relation,relationPhone1,relationPhone2,relationPhone3,relationAddress,relationGovernorate,demographic,demographicType,demographicSince,packsNumber,alcoholIntake,menstrual,LMP,LMPDate,contraception,pregnancyatDiagnosis")] patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.birthDate != null)
                {
                    patient.age = DateTime.Now.Year - patient.birthDate.Value.Year;

                    if (patient.birthDate.Value.Month>DateTime.Now.Month){
                        patient.age--;
                    }
                    else if (patient.birthDate.Value.Month == DateTime.Now.Month)
                    {
                        if(patient.birthDate.Value.Day>DateTime.Now.Day){
                            patient.age--;
                        }
                    }
                }
                patient.id = Guid.NewGuid();
                db.patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", patient.doctorId);
            return View(patient);
        }

        // GET: patients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", patient.doctorId);
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,diagnosis,diagnosisCode,notes,masterStatus,dateofDiagnosis,firstStatus,dateofRelapse,firstPresentationDate,birthDate,doctorId,age,gender,referredFrom,education,nationality,maritalStatus,occupation,noofChildren,ageofOldest,ageofYoungest,phone1,phone2,phone3,email,governorate,address,relationName,relation,relationPhone1,relationPhone2,relationPhone3,relationAddress,relationGovernorate,demographic,demographicType,demographicSince,packsNumber,alcoholIntake,menstrual,LMP,LMPDate,contraception,pregnancyatDiagnosis")] patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.birthDate != null)
                {
                    patient.age = DateTime.Now.Year - patient.birthDate.Value.Year;

                    if (patient.birthDate.Value.Month > DateTime.Now.Month)
                    {
                        patient.age--;
                    }
                    else if (patient.birthDate.Value.Month == DateTime.Now.Month)
                    {
                        if (patient.birthDate.Value.Day > DateTime.Now.Day)
                        {
                            patient.age--;
                        }
                    }
                }
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", patient.doctorId);
            return View(patient);
        }

        // GET: patients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            patient patient = db.patients.Find(id);
            db.patients.Remove(patient);
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
