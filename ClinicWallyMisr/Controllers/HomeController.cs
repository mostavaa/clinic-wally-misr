using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicWallyMisr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult constants()
        {
            return View();
        }
        public ActionResult RemoveConstant(string constant , string value)
        {
            if (constant == "" || constant == null || constant == string.Empty || value == "" || value == null || value == string.Empty)
                return RedirectToAction("constants");
            Constants.remove(constant, value);
            return RedirectToAction("constants");
        }
        public ActionResult AddConstant(string constant, string value)
        {
            if (constant == "" || constant == null || constant == string.Empty || value == "" || value == null || value == string.Empty)
                return RedirectToAction("constants");
            Constants.add(constant, value);
            return RedirectToAction("constants");
            
        }
    }
}