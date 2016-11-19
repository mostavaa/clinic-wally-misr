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
    public class GroupsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();

        // GET: Groups
        public ActionResult Index()
        {
            if (HomeController.Authorized(this))
            {
                return View(db.Groups.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            if (HomeController.Authorized(this))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Group group)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                group.id = Guid.NewGuid();
                db.Groups.Add(group);
                db.SaveChanges();
                createPermissions(group.id);
                return RedirectToAction("Index");
            }

            return View(group);
        }
        private void createPermissions(Guid groupId)
        {
            foreach (var item in db.Tables)
            {
                Permission permission = new Permission()
                {
                    groupId = groupId,
                    id = Guid.NewGuid(),
                    tableId = item.id
                };
                db.Permissions.Add(permission);
            }
            db.SaveChanges();
        }

        // GET: Groups/Edit/5
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
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Group group)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
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
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
