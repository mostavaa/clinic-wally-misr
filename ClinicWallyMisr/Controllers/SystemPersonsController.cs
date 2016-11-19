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
    public class SystemPersonsController : Controller
    {
        //TODO solve problem of datepicker
        SystemPersonService _personService = new SystemPersonService();
        DBService<Job> _jobService = new JobService();
        SpecializationService _specializationService = new SpecializationService();
        // GET: SystemPersons
        public ActionResult Index()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            List<SystemPerson> systemPersons = _personService.getAll().Include(s => s.Job).Include(s => s.Specialization).ToList();
            if ((Request.QueryString["acc.name"] != string.Empty && Request.QueryString["acc.name"] != null)
                || (Request.QueryString["jobId"] != string.Empty && Request.QueryString["jobId"] != null)
            || (Request.QueryString["specializationId"] != string.Empty && Request.QueryString["specializationId"] != null))
            {
                if (Request.QueryString["jobId"] != string.Empty)
                {
                    Guid job_id ;
                        if(Guid.TryParse(Request.QueryString["jobId"]  ,out job_id)){
                            systemPersons = systemPersons.Where(o => o.jobId == job_id).ToList();
                        }
                }
                if (Request.QueryString["specializationId"] != string.Empty)
                {
                    Guid specialization_id;
                    if (Guid.TryParse(Request.QueryString["specializationId"], out specialization_id))
                    {
                        systemPersons = systemPersons.Where(o => o.specializationId == specialization_id).ToList();
                    }
                }

                if (Request.QueryString["acc.name"] != string.Empty)
                {
                    systemPersons = systemPersons.Where(o => o.name == Request.QueryString["acc.name"]).ToList();
                }

            }
            ViewBag.jobId = new SelectList(_jobService.getAll(), "id", "name");
            ViewBag.specializationId = new SelectList(new List<Specialization>(), "id", "name");
            return View(systemPersons);
        }

        // GET: SystemPersons/Details/5
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
            SystemPerson systemPerson = _personService.get(id??Guid.Empty);
            if (systemPerson == null)
            {
                return HttpNotFound();
            }
            return View(systemPerson);
        }

        // GET: SystemPersons/Create
        public ActionResult Create()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.jobId = new SelectList(_jobService.getAll(), "id", "name");
            ViewBag.specializationId = new SelectList(new List<Specialization>(), "id", "name");
            return View();
        }
        private string[] allowedExtensions = new string[]{".pdf" , ".doc" , ".docx" , ".txt"};
        private string  uploadFile(string id)
        {
            var file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentLength<8*1024*1024)
            {
                file.SaveAs(Path.Combine(Server.MapPath("~/App_Data/fileUploads"),id+Path.GetFileName(file.FileName)));
            }
            return id+ Path.GetFileName(file.FileName);
        }
        // POST: SystemPersons/Createt
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemPerson systemPerson)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].FileName!="")
                {
                    if (allowedExtensions.Contains(Path.GetExtension(Request.Files[0].FileName)))
                    {
                        systemPerson.cv = uploadFile(systemPerson.id.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError("cv", "only pdf , doc , docx and txt files allowed");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                systemPerson.id = Guid.NewGuid();
                _personService.add(systemPerson);
                return RedirectToAction("Index");
            }

            ViewBag.jobId = new SelectList(_jobService.getAll(), "id", "name", systemPerson.jobId);
            ViewBag.specializationId = new SelectList(new List<Specialization>(), "id", "name", systemPerson.specializationId);
            return View(systemPerson);
        }

        // GET: SystemPersons/Edit/5
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
            SystemPerson systemPerson = _personService.get(id??Guid.Empty);
            if (systemPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobId = new SelectList(_jobService.getAll(), "id", "name", systemPerson.jobId);
            ViewBag.specializationId = new SelectList(_jobService.get(systemPerson.jobId).Specializations, "id", "name", systemPerson.specializationId);
            return View(systemPerson);
        }

        // POST: SystemPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SystemPerson systemPerson)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].FileName != "")
                {
                    if (allowedExtensions.Contains(Path.GetExtension(Request.Files[0].FileName)))
                    {

                        string rootFolderPath = Request.MapPath("~/App_Data/fileUploads/");
                        var dir = new DirectoryInfo(rootFolderPath);

                        foreach (var file in dir.EnumerateFiles(systemPerson.id.ToString()+"*.*"))
                        {
                            file.Delete();
                        }
                        systemPerson.cv = uploadFile(systemPerson.id.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError("cv", "only pdf , doc , docx and txt files allowed");
                    }
                }
                else
                {

                    if (Request["oldCV"] != null && Request["oldCV"] != string.Empty)
                        systemPerson.cv = Request["oldCV"];
                }
            }
            else
            {
                if (Request["oldCV"] != null && Request["oldCV"] != string.Empty)
                    systemPerson.cv = Request["oldCV"];
            }
            if (ModelState.IsValid)
            {
                _personService.edit(systemPerson);
                return RedirectToAction("Index");
            }
            ViewBag.jobId = new SelectList(_jobService.getAll(), "id", "name", systemPerson.jobId);
            ViewBag.specializationId = new SelectList(_jobService.get(systemPerson.jobId).Specializations, "id", "name", systemPerson.specializationId);
            return View(systemPerson);
        }

        // GET: SystemPersons/Delete/5
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
            SystemPerson systemPerson = _personService.get(id??Guid.Empty);
            if (systemPerson == null)
            {
                return HttpNotFound();
            }
            return View(systemPerson);
        }

        public FileResult displayFile(string filePath)
        {
            if (Path.GetExtension(Server.MapPath("~/App_Data/fileUploads/" + filePath)) == ".pdf")
            {
                return File(Server.MapPath("~/App_Data/fileUploads/" + filePath), "application/pdf");
            }
            else if (Path.GetExtension(Server.MapPath("~/App_Data/fileUploads/" + filePath)) == ".doc" )
            {
                return File(Server.MapPath("~/App_Data/fileUploads/" + filePath), "application/msword");
            }
            else if (Path.GetExtension(Server.MapPath("~/App_Data/fileUploads/" + filePath)) == ".docx")
            {
                return File(Server.MapPath("~/App_Data/fileUploads/" + filePath), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            else if (Path.GetExtension(Server.MapPath("~/App_Data/fileUploads/" + filePath))==".txt")
            {
                return File(Server.MapPath("~/App_Data/fileUploads/" + filePath), "text/plain");
            }
            else
            {
                return File(Server.MapPath("~/App_Data/fileUploads/" + filePath),null);
            }

        }
        // POST: SystemPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            SystemPerson systemPerson = _personService.get(id);
            _personService.delete(systemPerson);
            return RedirectToAction("Index");
        }
    }
}
