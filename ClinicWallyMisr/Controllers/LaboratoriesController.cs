using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicWallyMisr;
using System.IO;

namespace ClinicWallyMisr.Controllers
{
    public class LaboratoriesController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        visitService _visitService = new visitService();

        // GET: Laboratories
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
            var laboratories = db.Laboratories.Where(l => l.visitId == id).Include(l => l.visit);
            return View(laboratories.ToList());
        }



        // GET: Laboratories/Create
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

        // POST: Laboratories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Laboratory1,DateofLab,visitId")] Laboratory laboratory)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                laboratory.id = Guid.NewGuid();
                db.Laboratories.Add(laboratory);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = laboratory.visitId });
            }
            if (laboratory.visitId == null)
                return HttpNotFound();

            visit visit = _visitService.get(laboratory.visitId);
            if (visit == null)
                return HttpNotFound();
            ViewBag.visit = visit;
            return View(laboratory);
        }

        // GET: Laboratories/Edit/5
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
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // POST: Laboratories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Laboratory1,DateofLab,visitId")] Laboratory laboratory)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                db.Entry(laboratory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = laboratory.visitId });
            }
            return View(laboratory);
        }

        // GET: Laboratories/Delete/5
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
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // POST: Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            Guid visitId = (Guid)laboratory.visitId;
            db.Laboratories.Remove(laboratory);
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
        public void removeLab(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return;
            LabService _labService = new LabService();
            Lab lab = _labService.get(id);
            if (lab != null)
                _labService.delete(lab);
            Response.Write("1");
        }
        public void addLab(string newLabType, string newLabName, int newLabResult, string newLabUnit, string newLabResultStatus, Guid? id)
        {
            if (newLabName != string.Empty && newLabName != null && id != null && id != Guid.Empty)
            {
                LaboratoryService _laboratoryService = new LaboratoryService();
                Laboratory laboratory = _laboratoryService.get(id);
                if (laboratory == null)
                    return;
                Lab lab = new Lab()
                {
                    id = Guid.NewGuid(),
                    LabType = newLabType,
                    Name = newLabName,
                    result = newLabResult,
                    Unit = newLabUnit,
                    ResultStatus = newLabResultStatus,
                    LaboratoryId = id
                };
                LabService _labService = new LabService();
                _labService.add(lab);
                Response.Write("1");
            }
            else Response.Write("9");
        }
        //TODO upload graph
        public ActionResult uploadGraph()
        {

            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].FileName != "")
                {
                    string rootFolderPath = Request.MapPath("~/App_Data/labGraphs/");
                    var dir = new DirectoryInfo(rootFolderPath);

                    foreach (var file in dir.EnumerateFiles(Request["labId"] + "*.*"))
                    {
                        file.Delete();
                    }
                    uploadFile(Request["labId"]);
                }
            }
            return RedirectToAction("Edit", new { id = Request["labId"] });
        }
        private string uploadFile(string id)
        {
            var file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentLength < 8 * 1024 * 1024)
            {
                file.SaveAs(Path.Combine(Server.MapPath("~/App_Data/labGraphs"), id + Path.GetFileName(file.FileName)));
            }
            return id + Path.GetFileName(file.FileName);
        }
    }
}
