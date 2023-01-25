using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your application description page.";
            if (DateTime.Now.Hour < 12)
            {
                ViewBag.lblGreeting = "Good Morning " ;
            }
            else if (DateTime.Now.Hour < 17)
            {
                ViewBag.lblGreeting = "Good Afternoon " ;
            }
            else
            {
                ViewBag.lblGreeting = "Good Evening " ;
            }
            return View();
        }
    }
}