using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class CreatePurchaseController : Controller
    {
        // GET: CreatePurchase view
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatePurchase()
        {
            return View();
        }
    }
}