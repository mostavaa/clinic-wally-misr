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
    public class ReservationsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: Reservations
        public ActionResult Index()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            var reservations = db.Reservations.Include(r => r.SystemPerson).ToList();
            if ((Request.QueryString["roomNumberQ"] != string.Empty && Request.QueryString["roomNumberQ"] != null) ||
               (Request.QueryString["doctorIdsearch"] != string.Empty && Request.QueryString["doctorIdsearch"] != null)
               )
            {
                if ((Request.QueryString["doctorIdsearch"] != string.Empty && Request.QueryString["doctorIdsearch"] != null))
                {
                                        Guid doctorId ;
                        if(Guid.TryParse(Request.QueryString["doctorIdsearch"]  ,out doctorId)){
                            reservations = reservations.Where(r => r.doctorId == doctorId).ToList();
                        }
                }
                if ((Request.QueryString["roomNumberQ"] != string.Empty && Request.QueryString["roomNumberQ"] != null))
                {
                      reservations= reservations.Where(o => o.roomNumber.ToLower().Contains(Request.QueryString["roomNumberQ"])).ToList();
                }
            }

            ViewBag.doctorIdsearch = new SelectList(db.SystemPersons.Where(d=>d.Job.name.ToLower().Contains("doctor")), "id", "name");
            return View(reservations);
        }

        // GET: Reservations/Details/5
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
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.doctorId = new SelectList(db.SystemPersons.Where(d=>d.Job.name.ToLower().Contains("doctor")), "id", "name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patientName,fromTime,toTime,reservationType,notes,status,doctorId,roomNumber")] Reservation reservation)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                reservation.id = Guid.NewGuid();
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", reservation.doctorId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
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
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", reservation.doctorId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patientName,fromTime,toTime,reservationType,notes,status,doctorId,roomNumber")] Reservation reservation)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.SystemPersons, "id", "name", reservation.doctorId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
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
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
