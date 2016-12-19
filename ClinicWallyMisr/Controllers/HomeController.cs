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

        public ActionResult RemoveConstant(string constant, string value)
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

        private static Dictionary<string, string> tablePages = new Dictionary<string, string>() 
        { 
            {"endoscopies" ,"Endoscopy"},
            {"endoscopiesindex" ,"Endoscopy"},
            {"endoscopiesedit" ,"Endoscopy"},
            {"endoscopiescreate" ,"Endoscopy"},
            {"endoscopiedelete","Endoscopy"},
            {"endoscopiesdeleteconfirmed" ,"Endoscopy"},

            {"reservations","Reservation"},
            {"reservationsindex","Reservation"},
            {"reservationscreate","Reservation"},
            {"reservationsedit","Reservation"},
            {"reservationsdelete","Reservation"},
            {"reservationsdeleteconfirmed","Reservation"},
            {"reservationsdetails","Reservation"},

            {"laboratories","Laboratory"},
            {"laboratoriesindex","Laboratory"},
            {"laboratoriescreate","Laboratory"},
            {"laboratoriesdelete","Laboratory"},
            {"laboratoriesedit","Laboratory"},
            {"laboratoriesdeleteconfirmed","Laboratory"},


            {"medicines","medicine"},
            {"medicinesindex","medicine"},
            {"medicinescreate","medicine"},
            {"medicinesdelete","medicine"},
            {"medicinesedit","medicine"},
            {"medicinesdeleteconfirmed","medicine"},

            {"imagings","Imaging"},
            {"imagingsindex","Imaging"},
            {"imagingscreate","Imaging"},
            {"imagingsdelete","Imaging"},
            {"imagingsedit","Imaging"},
            {"imagingsdeleteconfirmed","Imaging"},

            {"accounts","Account"},
            {"accountsindex","Account"},
            {"accountsedit","Account"},
            {"accountscreate","Account"},
            {"accountsdelete","Account"},
            {"accountsdeleteconfirmed","Account"},

            {"patients","patient"},
            {"patientsindex","patient"},
            {"patientscreate","patient"},
            {"patientsdelete","patient"},
            {"patientsedit","patient"},
            {"patientsdeleteconfirmed","patient"},

            {"groups","Group"},
            {"groupsindex","Group"},
            {"groupscreate","Group"},
            {"groupsdelete","Group"},
            {"groupsdeleteconfirmed","Group"},
            {"groupsedit","Group"},


            {"specializations","Specialization"},
            {"specializationsindex","Specialization"},
            {"specializationscreate","Specialization"},
            {"specializationsdelete","Specialization"},
            {"specializationsedit","Specialization"},
            {"specializationsdeleteconfirmed","Specialization"},
            {"specializationsdetails","Specialization"},

            {"permissions","Permissions"},
            {"permissionsindex","Permissions"},
            {"permissionsedit","Permissions"},
            
            {"prescriptions","prescription"},
            {"prescriptionsindex","prescription"},
            {"prescriptionscreate","prescription"},
            {"prescriptionsdelete","prescription"},
            {"prescriptionsedit","prescription"},
            {"prescriptionsdeleteconfirmed","prescription"},

            {"systempersons","SystemPerson"},
            {"systempersonsindex","SystemPerson"},
            {"systempersonscreate","SystemPerson"},
            {"systempersonsdelete","SystemPerson"},
            {"systempersonsedit","SystemPerson"},
            {"systempersonsdeleteconfirmed","SystemPerson"},
            {"systempersonsdetails","SystemPerson"},

            {"jobs","Job"},
            {"jobsindex","Job"},
            {"jobscreate","Job"},
            {"jobsedit","Job"},
            {"jobsdelete","Job"},
            {"jobsdeleteconfirmed","Job"},
            {"jobsdetails","Job"},

            {"visits","visits"},
            {"visitsindex","visits"},
            {"visitsedit","visits"},
            {"visitsdelete","visits"},
            {"visitscreate","visits"},
            {"visitsdeleteconfirmed","visits"},

            {"examinations","examination"},
            {"examinationsindex","examination"},
            {"examinationscreate","examination"},
            {"examinationsdelete","examination"},
            {"examinationsdeleteconfirmed","examination"},
            {"examinationsedit","examination"},
        };

        internal static bool Authorized(Controller controller)
        {
            ClinicWallyMisrEntities db = ClinicWallyMisrEntities.Instance;
            string uri, table;
            if (controller.Session["username"] != null && controller.Session["username"] != string.Empty)
            {
                string username = controller.Session["username"] as string;
                if (username != null && username != string.Empty)
                {
                    Account account = db.Accounts.FirstOrDefault(u => u.name == username);
                    if (account != null)
                    {
                        if (!account.isAdmin)
                        {
                            uri = controller.Request.Url.AbsolutePath;
                            uri = uri.Replace("/", "");
                            uri = uri.Replace("\\", "");
                            uri = uri.ToLower();
                            table = "";
                            string key = tablePages.Keys.FirstOrDefault(k=>uri.Contains(k));
                            if (key != null && key != string.Empty)
                            {
                                table = tablePages[key];
                            }
                            if (table != "")
                            {
                                Table myTable = db.Tables.FirstOrDefault(o => o.tableName == table);
                                if (myTable != null)
                                {
                                    if (account.Group.Permissions.Where(o => o.tableId == myTable.id).Count() > 0)
                                    {
                                        Permission perms = account.Group.Permissions.FirstOrDefault(o => o.tableId == myTable.id);
                                        if (perms != null)
                                        {
                                            if (uri.Contains("create"))
                                            {
                                                if (perms.canAdd)
                                                    return true;
                                            }
                                            else if (uri.Contains("edit"))
                                            {
                                                if (perms.canEdit)
                                                    return true;
                                            }
                                            else if (uri.Contains("delete"))
                                            {
                                                if (perms.canDelete)
                                                    return true;
                                            }
                                            else
                                            {
                                                if (perms.canRead)
                                                    return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return true; // is admin
                        }
                    }
                }
            }
            return false;
        }
    }
}