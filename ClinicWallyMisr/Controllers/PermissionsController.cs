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
    public class PermissionsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        DBService<Group> _service = new GroupService();
        // GET: Permissions
        public ActionResult Index(Guid?id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null)
                return HttpNotFound();
            Group group = _service.get(id);
            if (group == null)
                return HttpNotFound();
            ViewBag.group = group;
            var permissions = db.Permissions.Where(a=>a.groupId==id).Include(p => p.Group).Include(p => p.Table);
            return View(permissions.ToList());
        }



        // GET: Permissions/Edit/5
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
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupId,tableId,canAdd,canEdit,canDelete,canRead")] Permission permission)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { @id=permission.groupId});
            }
            return View(permission);
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
