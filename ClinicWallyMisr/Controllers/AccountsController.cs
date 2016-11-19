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
    public class AccountsController : Controller
    {
        private ClinicWallyMisrEntities db = new ClinicWallyMisrEntities();
        private AccountService _service = new AccountService();
        // GET: Accounts
        public ActionResult Index()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Accounts.ToList());
        }

        public ActionResult Login()
        {
      
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
     
            if(account.name!=null &&account.name!=string.Empty && account.password!=null &&account.password!=string.Empty ){
                if (_service.getbyNameandPassword(account.name, account.password) != null)
                {
                    login(account.name);            
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("name" , "User Name or Password May Be Wrong !");
                }
            }
            else
            {
                ModelState.AddModelError("name", "Please Fill in User Name and Password !");
            }
            return View(account);
        }
        

        // GET: Accounts/Create
        public ActionResult Create()
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.groupId = new SelectList(db.Groups, "id", "name");

            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Account account)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (_service.getbyNameandPassword(account.name, account.password)!=null)
            {
                ModelState.AddModelError("name", "User Already Exisit , Please Choose Another one!");
            }
            if (ModelState.IsValid)
            {
                account.id = Guid.NewGuid();
                account.creationDate = DateTime.Now;
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groupId = new SelectList(db.Groups, "id", "name");
            return View(account);
        }
        private void login(string username)
        {
            Session.Add("username", username);
        }
        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }

        // GET: Accounts/Edit/5
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
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupId = new SelectList(db.Groups, "id", "name");
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groupId = new SelectList(db.Groups, "id", "name");
            return View(account);
        }

        // GET: Accounts/Delete/5
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
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!HomeController.Authorized(this))
            {
                return RedirectToAction("Index", "Home");
            }
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
